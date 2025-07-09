namespace Ans.Net8.Common
{

	public interface ICrudFace
	{
		string Name { get; set; }
		string Title { get; set; }

		string ShortTitle { get; }
		string Description { get; }
		string Sample { get; }
		string HelpLink { get; }
	}



	public class CrudFaceHelper
		: ICrudFace
	{

		/* ctors */


		public CrudFaceHelper(
			string name,
			string title,
			string shortTitle,
			string description,
			string sample,
			string helpLink)
		{
			Name = name;
			_init(title, shortTitle, description, sample, helpLink);
		}


		/// <param name="face">
		/// "title|shortTitle|description|sample|helpLink"
		/// </param>
		public CrudFaceHelper(
			string name,
			string face)
		{
			Name = name;
			Face = face;
		}


		/* properties */


		public string Name { get; set; }


		private string _title;
		public string Title
		{
			get => HasTitle ? _title : Name;
			set => _title = value;
		}


		/* readonly properties */


		private string _shortTitle;
		public string ShortTitle
		{
			get => HasShortTitle ? _shortTitle : Title;
			private set => _shortTitle = value;
		}


		public string Description { get; private set; }
		public string Sample { get; private set; }
		public string HelpLink { get; private set; }


		public string Face
		{
			get => string.Join("|", _title, _shortTitle, Description, Sample, HelpLink);
			private set
			{
				var a1 = new StringParser(value);
				_init(a1.Get(0), a1.Get(1), a1.Get(2), a1.Get(3), a1.Get(4));
			}
		}


		/* readonly properties */


		public bool HasTitle
			=> !string.IsNullOrEmpty(_title);


		public bool HasShortTitle
			=> !string.IsNullOrEmpty(_shortTitle);


		public bool HasDescription
			=> !string.IsNullOrEmpty(Description);


		public bool HasSample
			=> !string.IsNullOrEmpty(Sample);


		public bool HasHelpLink
			=> !string.IsNullOrEmpty(HelpLink);


		/* privates */


		private void _init(
			string title,
			string shortTitle,
			string description,
			string sample,
			string helpLink)
		{
			Title = title;
			ShortTitle = shortTitle;
			Description = description;
			Sample = sample;
			HelpLink = helpLink;
		}

	}

}
