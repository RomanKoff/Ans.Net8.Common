using System.Net.Http.Headers;

namespace Ans.Net8.Common
{

	public class ContentInfo(
		string extention,
		string contentType,
		ContentGroupEnum group,
		bool isWebImage = false,
		bool isJpeg = false)
	{
		public string Extention { get; } = extention;
		public string ContentType { get; } = contentType;
		public ContentGroupEnum Group { get; } = group;
		public bool IsWebImage { get; } = isWebImage;
		public bool IsJpeg { get; } = isJpeg;

		public MediaTypeHeaderValue MediaType
			=> _mediaType ??= new MediaTypeHeaderValue(ContentType);
		private MediaTypeHeaderValue _mediaType;
	}



	public enum ContentGroupEnum
	{
		Archive,
		Audio,
		Bin,
		Code,
		Document,
		Image,
		Text,
		Video
	}

}
