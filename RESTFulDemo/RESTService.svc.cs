/*
 * Created by SharpDevelop.
 * User: sawangcs
 * Date: 04/03/2016
 * Time: 17:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace RESTFulDemo
{
	[ServiceContract]
	public interface IRESTService
	{
		//POST operation
		[OperationContract]
		[WebInvoke(UriTemplate = "", Method = "POST")]
		Person CreatePerson(Person createPerson);

		//Get Operation
		[OperationContract]
		[WebGet(UriTemplate = "")]
		List<Person> GetAllPerson();
		
		[OperationContract]
		[WebGet(UriTemplate = "{id}")]
		Person GetPerson(string id);

		//PUT Operation
		[OperationContract]
		[WebInvoke(UriTemplate = "{id}", Method = "PUT")]
		Person UpdatePerson(string id, Person updatePerson);

		//DELETE Operation
		[OperationContract]
		[WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
		void DeletePerson(string id);
	}

	/// <summary>
	/// Description of RESTService.
	/// </summary>
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class RESTService : IRESTService
	{
		List<Person> persons = new List<Person>();
		int personCount = 0;

		public Person CreatePerson(Person createPerson)
		{
			createPerson.ID = (++personCount).ToString();
			persons.Add(createPerson);
			return createPerson;
		}
    
		public List<Person> GetAllPerson()
		{
			return persons.ToList();
		}

		public Person GetPerson(string id)
		{
			return persons.FirstOrDefault(e => e.ID.Equals(id));
		}

		public Person UpdatePerson(string id, Person updatePerson)
		{
			Person p = persons.FirstOrDefault(e => e.ID.Equals(id));
			p.Name = updatePerson.Name;
			p.Age = updatePerson.Age;
			return p;
		}

		public void DeletePerson(string id)
		{
			persons.RemoveAll(e => e.ID.Equals(id));
		}
	}
}
