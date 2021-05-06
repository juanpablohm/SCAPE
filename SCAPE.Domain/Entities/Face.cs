using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Domain.Entities
{
    public class Face
    {

        public Guid? FaceId { get; set; }

        public int[] FaceRectangle { get; set; }


        public Face(Guid? faceId, int[] faceRectangle)
        {
            FaceId = faceId;
            FaceRectangle = faceRectangle;
        }
    }
}
