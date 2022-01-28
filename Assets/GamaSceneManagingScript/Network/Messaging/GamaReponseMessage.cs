using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AssemblyCSharp.Assets.GamaSceneManagingScript.Utils.Serializer;

namespace ummisco.gama.unity.messages
{
	[Serializable]
	[System.Xml.Serialization.XmlRoot ("ummisco.gama.unity.messages.GamaReponseMessage")]
	public class GamaReponseMessage
	{
		public Boolean unread;

		public string sender;

		public string receivers;


		public string contents;

		public string emissionTimeStamp;


		public GamaReponseMessage ()
		{
			
		}

		public GamaReponseMessage (string sender, string receivers, string contents, string emissionTimeStamp)
		{
			this.unread = true;
			this.sender = sender;
			this.receivers = receivers;
			this.contents = contents;
			this.emissionTimeStamp = emissionTimeStamp;
		}

	}
	/*
	/// <summary>
	/// Converts an object to its serialized XML format.
	/// </summary>
	/// <typeparam name="T">The type of object we are operating on</typeparam>
	/// <param name="value">The object we are operating on</param>
	/// <param name="removeDefaultXmlNamespaces">Whether or not to remove the default XML namespaces from the output</param>
	/// <param name="omitXmlDeclaration">Whether or not to omit the XML declaration from the output</param>
	/// <param name="encoding">The character encoding to use</param>
	/// <returns>The XML string representation of the object</returns>
	public static string ToXmlString<T>(this T value, bool removeDefaultXmlNamespaces = true, bool omitXmlDeclaration = true, Encoding encoding = null) where T : class
	{
		XmlSerializerNamespaces namespaces = removeDefaultXmlNamespaces ? new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }) : null;

		var settings = new XmlWriterSettings();
		settings.Indent = true;
		settings.OmitXmlDeclaration = omitXmlDeclaration;
		settings.CheckCharacters = false;

		using (var stream = new StringWriterWithEncoding(encoding))
		using (var writer = XmlWriter.Create(stream, settings)) {
			var serializer = new XmlSerializer(value.GetType());
			serializer.Serialize(writer, value, namespaces);
			return stream.ToString();
		}

		*/
}

