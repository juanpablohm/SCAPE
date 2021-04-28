using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Entities
{
    public class Face
    {

        private string FaceId { get; set; }

        private int[] FaceRectangle { get; set; }


        public Face(String faceId, int[] faceRectangle)
        {
            FaceId = faceId;
            FaceRectangle = faceRectangle;
        }
    }
}
