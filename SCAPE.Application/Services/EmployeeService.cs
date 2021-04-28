using SCAPE.Application.DTOs;
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

            return employee;
        }

        /// <summary>
        /// This method contain bussiness logic
        /// Insert employee from repository
        /// </summary>
        /// <param name="employee">Employee yo insert</param>
        public async Task insertEmployee(Employee employee)
        {
            await _employeeRepository.insertEmployee(employee);
        }

        public async Task<Employee> findEmployee(string documentId)
        {
            return await _employeeRepository.findEmployee(documentId);

        }
    }
}
