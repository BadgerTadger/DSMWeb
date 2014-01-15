using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Configuration;
using BLL;

public partial class Dogs_AddBreed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MessageLabel.Text = string.Empty;

        if (!Page.IsPostBack)
        {
            string returnChars = Request.QueryString["return"];
            btnReturn.PostBackUrl = Common.ReturnPath(Request.QueryString, returnChars, null);
        }
    }
    protected void btnAddBreed_Click(object sender, EventArgs e)
    {
        string strDogBreed = txtNewBreed.Text;
        if (!string.IsNullOrEmpty(strDogBreed))
        {
            DogBreeds dogBreeds = new DogBreeds();
            int? newDogBreedID = dogBreeds.Insert_Dog_Breed(strDogBreed);

            if (newDogBreedID != null && newDogBreedID > 0)
            {
                MessageLabel.Text = string.Format("{0} was added to the Dog Breed Table", strDogBreed);
            }
            else
            {
                MessageLabel.Text = "Error inserting the record";
            }
        }
        else
        {
            MessageLabel.Text = "Nothing Entered!";
        }
    }
}