using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using SCAPE.Application.Interfaces;
using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SCAPE.Infraestructure.FaceRecognition
{
    public class FaceRecognition : IFaceRecognition
    {

        private readonly string API_KEY = "06a113919fff4bdaa0a5477687bb1ad8";
        private readonly string ENDPOINT = "https://southcentralus.api.cognitive.microsoft.com/";

        public async Task<string> addFaceAsync(string encodeImage, string faceListId)
        {
            IFaceClient client = Authenticate(ENDPOINT, API_KEY);

            Stream image = convertEncodeImageToStream(encodeImage);

            var persistedFace =  await client.FaceList.AddFaceFromStreamAsync(faceListId, image, detectionModel: DetectionModel.Detection01);

            return persistedFace.PersistedFaceId.ToString();

        }

        public async Task<Face> detectFaceAsync(string encodeImage, string faceListId)
        {
            IFaceClient client = Authenticate(ENDPOINT, API_KEY);

            Stream image = convertEncodeImageToStream(encodeImage);

            var detectedFaces = await client.Face.DetectWithStreamAsync(image, returnFaceId: true, detectionModel: DetectionModel.Detection01, recognitionModel: RecognitionModel.Recognition03);
            
            if(detectedFaces.Count != 1)
            {
                return null;
            }

            DetectedFace face = detectedFaces[0];
            int[] faceRectangle = { face.FaceRectangle.Top, face.FaceRectangle.Left, face.FaceRectangle.Height, face.FaceRectangle.Width };

            Face newFace = new Face(face.FaceId, faceRectangle );

            return newFace;

        }

        public async Task<string> findSimilar(Face face, string faceListId)
        {
            IFaceClient client = Authenticate(ENDPOINT, API_KEY);

            List<SimilarFace> similarFaces = (List<SimilarFace>) await client.Face.FindSimilarAsync((Guid)face.FaceId, faceListId);

            if (similarFaces.Count != 1)
            {
                return null;
            }

            return similarFaces[0].PersistedFaceId.ToString();
        }

        private static IFaceClient Authenticate(string endpoint, string key)
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }

        private Stream convertEncodeImageToStream(string encodeImage)
        {
            byte[] bytesImage = Convert.FromBase64String(encodeImage);
            MemoryStream memoryStream = new MemoryStream(bytesImage);
            return memoryStream;
        }

    }
}
