﻿using SCAPE.Application.DTOs;
using SCAPE.Application.Interfaces;
using SCAPE.Domain.Entities;
using SCAPE.Domain.Exceptions;
using SCAPE.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace SCAPE.Application.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFaceRecognition _faceRecognition;

        public EmployeeService(IEmployeeRepository employeeRepository, IFaceRecognition faceRecognition)
        {
            _employeeRepository = employeeRepository;
            _faceRecognition = faceRecognition;
        }
        /// <summary>
        /// This method contain bussiness logic 
        /// Associate face to Employye
        /// </summary>
        /// <param name="documentId">string with employee document id</param>
        /// <param name="encodeImage">string with encoded image</param>
        /// <returns>
        /// if there is not employee return a error message,
        /// if there is not face detected return a error message,
        /// if there is already register face return a error message,
        /// if insert success, return true
        /// </returns>
        public async Task<bool> associateFace(string documentId, string encodeImage)
        {
            Employee employee = await findEmployee(documentId);

            if(employee == null)
            {
                throw new EmployeeDocumentException("Employee's document is not valid");
            }
                
            Face faceDetected = await _faceRecognition.detectFaceAsync(encodeImage,employee.FaceListId);

            if(faceDetected == null)
            {
                throw new FaceRecognitionException("The image must contain only one face");
            }

            string persistenFaceId = await _faceRecognition.addFaceAsync(encodeImage, employee.FaceListId);


            byte[] bytesImage = Convert.FromBase64String(encodeImage);
            await _employeeRepository.saveImageEmployee(new EmployeeImage(persistenFaceId, employee.Id, bytesImage));

            return true;
        }
        /// <summary>
        /// This method contain bussiness logic 
        /// get employee by face
        /// </summary>
        /// <param name="encodeImage">string with encoded image</param>
        /// <param name="faceListId">string with face list id</param>
        /// <returns>
        /// if there is not face detected return a error message,
        /// if there is not face similiar return a error message,
        /// if there is not associate employee at face, return a error message,
        /// if get success, return Employee
        /// </returns>
        public async Task<Employee> getEmployeeByFace(string encodeImage, string faceListId)
        {
            Face faceDetected = await _faceRecognition.detectFaceAsync(encodeImage, faceListId);

            if (faceDetected == null)
            {
                throw new FaceRecognitionException("The image must contain only one face");
            }

            string persistedFaceId = await _faceRecognition.findSimilar(faceDetected, faceListId);

            if (persistedFaceId == null)
            {
                throw new FaceRecognitionException("No persistedFaceid found for this face");
            }

            Employee employee = await _employeeRepository.findEmployeeByPersistedFaceId(persistedFaceId);

            if (employee == null)
            {
                throw new EmployeeException("No Employee found in Database for this persistedFaceId");
            }

            return employee;
        }

        /// <summary>
        /// This method contain bussiness logic
        /// Insert employee from repository
        /// </summary>
        /// <param name="employee">Employee to insert</param>
        public async Task insertEmployee(Employee employee)
        {
            await _employeeRepository.insertEmployee(employee);
        }

        /// <summary>
        /// Find employee from repository
        /// </summary>
        /// <param name="documentId">DocumentId from employee to find</param>
        /// <returns>Employee associate to this documentId</returns>
        public async Task<Employee> findEmployee(string documentId)
        {
            return await _employeeRepository.findEmployee(documentId);

        }
    }
}
