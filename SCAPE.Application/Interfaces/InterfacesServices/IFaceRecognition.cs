using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCAPE.Application.Interfaces
{
    public interface IFaceRecognition
    {
        Task<Face> detectFaceAsync(String encodeImage);
        Task<String> addFaceAsync(String encodeImage, String faceListId);
        Task<String> findSimilar(Face face, String faceListId);
    }
}
