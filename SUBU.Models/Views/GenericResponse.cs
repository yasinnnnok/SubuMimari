namespace SUBU.Models;

public class GenericResponse
{
	#region Constructors
	public GenericResponse() : this(true, null, null)
	{
	}

	public GenericResponse(string message) : this(true, message, null)
	{
	}
	public GenericResponse(bool success, string message) : this(success, message, null)
	{

	}
	public GenericResponse(bool success, string message, object data)
	{
		this.success = success;
		this.message = message;
		this.data = data;
	}

	#endregion

	#region Private Members

	private bool success;
	private string message;
	private object data;

	#endregion

	#region Properties

	public bool Success
	{
		get
		{
			return success;
		}
		set { success = value; }
	}

	public string Message
	{
		get
		{
			return message;
		}
		set { message = value; }
	}

	public object Data
	{
		get
		{
			return data;
		}
		set { data = value; }
	}


	#endregion
}
