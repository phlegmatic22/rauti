
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Resources;
using System.Reflection;
using Metso.DNA.IA.DNAdata.Interfaces;
using Metso.DNA.IA.DNAdata;
using Metso.DNA.ProReports.Interfaces;      
using System.Windows.Forms;


/// <summary>
///	Summary description for ForcedUpdate header.
/// </summary>
public partial class ForcedUpdate : System.Web.UI.UserControl, Metso.DNA.ProReports.Interfaces.IReportHeader     
{
	
	public int update_minute = 1; 
	public string start_time = ""; 
	public string report_path = ""; 
	public string help = "hö"; 
	
	protected void Page_Load(object sender, System.EventArgs e)
	{
		// TODO: Any additional logic
		
	}

	#region IReportHeader implementation

	// These events are used by the control panel to trigger different functions 
	// in report viewer
	
	/// <summary>
	/// Report update request (retrieve data and render report)
	/// </summary>
	public event System.EventHandler UpdateRequest;

	/// <summary>
	/// Report print request
	/// </summary>
	public event System.EventHandler PrintRequest;

	/// <summary>
	/// Report parameter edit request. In BaseHeader.ascx this will
	/// bring up the default parameter editor dialog
	/// </summary>
	public event System.EventHandler EditRequest;

	/// <summary>
	/// Report viewer About request
	/// </summary>
	public event System.EventHandler AboutRequest;

	/// <summary>
	/// Report viewer Help request
	/// </summary>
	public event System.EventHandler HelpRequest;
    
	// These functions are called from report viewer. They are 
	// used to pass report parameter information between the 
	// report viewer and the control panel 

	/// <summary>
	/// Report viewer uses this method to query report parameters 
	/// from this control panel
	/// </summary>
	/// <param name="headerParameters">Report parameters from DNAreport</param>
	/// <returns>Modified report parameters</returns>
    public DataSet GetHeaderParameters(DataSet headerParameters)
    {
        return headerParameters;
    }

    /// <summary>
    /// Report viewer calls this method when this control
    /// panel gets loaded 
    /// </summary>
    /// <param name="headerParameters">Report parameters from DNAreport</param>
    public void Initialize(DataSet headerParameters)
    {	
		try{
			
			
			update_minute = Convert.ToInt16(((DataRow)headerParameters.Tables[0].Select("Usage='UpdateMinute'")[0])["CurrentValue"]);
			report_path = Convert.ToString(((DataRow)headerParameters.Tables[0].Select("Usage='ReportPath'")[0])["CurrentValue"]);
			start_time = Convert.ToString(((DataRow)headerParameters.Tables[0].Select("Usage='StartTime'")[0])["CurrentValue"]);
			help = "moi";
		}catch{
			
			update_minute = 1;
		}
    }

    #endregion

    #region Test UI events

    protected void btnAbout_Click(object sender, System.EventArgs e)
    {
        if (this.AboutRequest != null)
        {
            //this.AboutRequest(this, e);
        }
    }
    protected void btnEdit_Click(object sender, System.EventArgs e)
    {
        if (this.EditRequest != null)
        {
            //this.EditRequest(this, e);
        }
    }

    protected void btnHelp_Click(object sender, System.EventArgs e)
    {
        if (this.HelpRequest != null)
        {
            //this.HelpRequest(this, e);
			
        }
    }

    protected void btnPrint_Click(object sender, System.EventArgs e)
    {
        if (this.PrintRequest != null)
        {
            
			
        }
    }

    protected void btnUpdate_Click(object sender, System.EventArgs e)
    {
        if (this.UpdateRequest != null)
        {
            //this.UpdateRequest(this, e);
        }
    }
    #endregion
    
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    ///		Required method for Designer support - do not modify
    ///		the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
    }
    #endregion
}