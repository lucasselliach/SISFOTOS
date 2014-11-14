using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;

namespace SisFotos.Controller
{
    public class TratamentoDeImagens
    {
        #region Public Properties

        public ImageCodecInfo JpgEnconder { get; private set; }
        public EncoderParameters EncoderParameters { get; private set; }
        public List<Bitmap> BitmapsTratada  { get; private set; }

        #endregion Public Properties
        
        #region Internal Properties
        #endregion Internal Properties
        
        #region Constructors/Destructor

        public TratamentoDeImagens(List<Bitmap> imagensParaRealizarTratamento)
        {
            BitmapsTratada = new List<Bitmap>();
            RealizarMelhoriasEmImagens(imagensParaRealizarTratamento);
        }

        #endregion Constructors/Destructor

        #region Public Methods
        #endregion Public Methods
        
        #region Internal Methods
        
        private void RealizarMelhoriasEmImagens(List<Bitmap> imagensParaRealizarTratamento)
        {
            JpgEnconder = GetEncoder(ImageFormat.Jpeg);
            EncoderParameters = new EncoderParameters(1);
            
            var encoder = Encoder.Quality;
            var encoderParameter = new EncoderParameter(encoder, 60L);
            EncoderParameters.Param[0] = encoderParameter;

            var contrastCorrection = new ContrastCorrection(30);

            foreach (var bitmap in imagensParaRealizarTratamento)
            {
                BitmapsTratada.Add(contrastCorrection.Apply(bitmap));
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        #endregion Internal Methods
        
        #region Events
        #endregion Events
    }
}
