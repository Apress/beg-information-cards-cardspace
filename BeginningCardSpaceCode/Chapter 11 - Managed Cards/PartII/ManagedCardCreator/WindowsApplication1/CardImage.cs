using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCardSpace
{
    public class CardImage
    {
        private string _imageName;
        private string _imageMimeType;

        public string ImageMimeType
        {
            get { return _imageMimeType; }

        }

        public string ImageName
        {
            get { return _imageName; }
            set
            {

                _imageName = value;
                switch (_imageName.Substring(_imageName.Length - 3).ToLower())
                {

                    case "bmp":
                        _imageMimeType = "image/bmp";
                        break;

                    case "gif":
                        _imageMimeType = "image/gif";
                        break;

                    case "jpg":
                        _imageMimeType = "image/jpeg";
                        break;
                    case "png":
                        _imageMimeType = "image/png";
                        break;
                    case "tif":

                        _imageMimeType = "image/tiff";
                        break;
                    case "tiff":

                        _imageMimeType = "image/tiff";
                        break;

                }


            }


        }
    }
}
