using LibDispensary;

namespace Solution.DispensaryForm;

public class CustomForm : Form
{
    private readonly List<string> _header = new();
    private readonly List<Dispensary> _dpList = new(); 
    private Label fullInfoLabel = new();
    private DataGridView grid = new();
    
    public CustomForm() {}
    public CustomForm(List<Dispensary> dpList, string header)
    {
        _dpList = dpList;
        _header = header.Split(';').ToList();
        
        InitializeComponent();
    }
    
    /// <summary>
    /// Inits form.
    /// </summary>
    private void InitializeComponent()
    {
        // Form setup.
        SetupForm();
        
        // FullInfoLabel setup.
        SetupFullInfoLabel();

        // Grid setup.
        SetupDataGridView();
        
        // Adding elements to ControlsCollection.
        Controls.Add(fullInfoLabel);
        Controls.Add(grid);
    }

    /// <summary>
    /// Setups form.
    /// </summary>
    private void SetupForm()
    {
        Size = new Size(1080, 660);
        Text = "Dispensary viewer";
    }

    /// <summary>
    /// Setups label.
    /// </summary>
    private void SetupFullInfoLabel()
    {
        fullInfoLabel = new Label();
        
        fullInfoLabel.Height = 60;
        fullInfoLabel.Width = 1080;
        
        fullInfoLabel.Text = "Here you can see chosen cell";
        fullInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
        fullInfoLabel.ForeColor = Color.FromArgb(50, 50, 50);
        fullInfoLabel.BackColor = Color.White;
        fullInfoLabel.Font = new Font("Arial", 12);
        
    }

    /// <summary>
    /// Setups grid.
    /// </summary>
    private void SetupDataGridView()
    {
        grid = new DataGridView();
        grid.Location = new Point(0, 60);
        grid.Width = 1060;
        grid.Height = 550;
        grid.ColumnCount = 26;
        grid.RowCount = _dpList.Count;
        
        grid.ReadOnly = true;
        grid.RowHeadersVisible = false;
        grid.AllowUserToResizeColumns = false;
        grid.AllowUserToResizeRows = false;
        
        FillGridHeader();
        FillGrid();

        if (_dpList.Count > 0)
        {
            grid.CellClick += handleCellHover!;
        }
    }

    /// <summary>
    /// Fills grid header with values.
    /// </summary>
    private void FillGridHeader()
    {
        for (int i = 0; i < 26; i++)
        {
            grid.Columns[i].HeaderCell.Value = _header[i];
            grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns[i].Resizable = DataGridViewTriState.False;
        }
    }

    /// <summary>
    /// Fills grid cells with values.
    /// </summary>
    private void FillGrid()
    {
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            grid.Rows[i].Height = 40;
            for (int j = 0; j < grid.Rows[i].Cells.Count; j++)
            {
                grid.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(50, 50, 50);
                grid.Rows[i].Cells[j].Style.ForeColor = Color.WhiteSmoke;
                grid.Rows[i].Cells[j].Value = _dpList[i].DataList[j];
            }
        }
    }

    /// <summary>
    /// Handler for cell to show it's data in label.
    /// </summary>
    private void handleCellHover(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) { return; }
        var cell = (DataGridViewTextBoxCell) grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        fullInfoLabel.Text = cell.Value.ToString();
    }
}