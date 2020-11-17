namespace Project1_Polygon_Editor
{
    partial class Polygon_Editor
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Polygon_Editor));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMove = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelMove = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMovePolygon = new System.Windows.Forms.Button();
            this.buttonMoveEdge = new System.Windows.Forms.Button();
            this.buttonMoveVertex = new System.Windows.Forms.Button();
            this.groupBoxDelete = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDelete = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeletePolygon = new System.Windows.Forms.Button();
            this.buttonDeleteRelation = new System.Windows.Forms.Button();
            this.buttonDeleteVertex = new System.Windows.Forms.Button();
            this.groupBoxAddRelation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelAddRelation = new System.Windows.Forms.TableLayoutPanel();
            this.buttonVertical = new System.Windows.Forms.Button();
            this.buttonHorizontal = new System.Windows.Forms.Button();
            this.buttonAngle = new System.Windows.Forms.Button();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelAdd = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddVertex = new System.Windows.Forms.Button();
            this.focusLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanelMenu.SuspendLayout();
            this.groupBoxMove.SuspendLayout();
            this.tableLayoutPanelMove.SuspendLayout();
            this.groupBoxDelete.SuspendLayout();
            this.tableLayoutPanelDelete.SuspendLayout();
            this.groupBoxAddRelation.SuspendLayout();
            this.tableLayoutPanelAddRelation.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.tableLayoutPanelAdd.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanelMenu, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1182, 725);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(998, 719);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // tableLayoutPanelMenu
            // 
            this.tableLayoutPanelMenu.ColumnCount = 1;
            this.tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMenu.Controls.Add(this.groupBoxMove, 0, 1);
            this.tableLayoutPanelMenu.Controls.Add(this.groupBoxDelete, 0, 2);
            this.tableLayoutPanelMenu.Controls.Add(this.groupBoxAddRelation, 0, 3);
            this.tableLayoutPanelMenu.Controls.Add(this.groupBoxAdd, 0, 0);
            this.tableLayoutPanelMenu.Controls.Add(this.focusLabel, 0, 4);
            this.tableLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMenu.Location = new System.Drawing.Point(1007, 3);
            this.tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            this.tableLayoutPanelMenu.RowCount = 5;
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMenu.Size = new System.Drawing.Size(172, 719);
            this.tableLayoutPanelMenu.TabIndex = 1;
            // 
            // groupBoxMove
            // 
            this.groupBoxMove.Controls.Add(this.tableLayoutPanelMove);
            this.groupBoxMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxMove.ForeColor = System.Drawing.Color.Black;
            this.groupBoxMove.Location = new System.Drawing.Point(3, 74);
            this.groupBoxMove.Name = "groupBoxMove";
            this.groupBoxMove.Size = new System.Drawing.Size(166, 65);
            this.groupBoxMove.TabIndex = 0;
            this.groupBoxMove.TabStop = false;
            this.groupBoxMove.Text = "Move";
            // 
            // tableLayoutPanelMove
            // 
            this.tableLayoutPanelMove.ColumnCount = 3;
            this.tableLayoutPanelMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanelMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelMove.Controls.Add(this.buttonMovePolygon, 0, 0);
            this.tableLayoutPanelMove.Controls.Add(this.buttonMoveEdge, 0, 0);
            this.tableLayoutPanelMove.Controls.Add(this.buttonMoveVertex, 0, 0);
            this.tableLayoutPanelMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMove.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelMove.Name = "tableLayoutPanelMove";
            this.tableLayoutPanelMove.RowCount = 1;
            this.tableLayoutPanelMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelMove.Size = new System.Drawing.Size(160, 44);
            this.tableLayoutPanelMove.TabIndex = 0;
            // 
            // buttonMovePolygon
            // 
            this.buttonMovePolygon.BackColor = System.Drawing.Color.White;
            this.buttonMovePolygon.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.polygon;
            this.buttonMovePolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMovePolygon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovePolygon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMovePolygon.ForeColor = System.Drawing.Color.Black;
            this.buttonMovePolygon.Location = new System.Drawing.Point(109, 3);
            this.buttonMovePolygon.Name = "buttonMovePolygon";
            this.buttonMovePolygon.Size = new System.Drawing.Size(48, 38);
            this.buttonMovePolygon.TabIndex = 8;
            this.buttonMovePolygon.TabStop = false;
            this.buttonMovePolygon.UseVisualStyleBackColor = false;
            this.buttonMovePolygon.Click += new System.EventHandler(this.buttonMovePolygon_Click);
            this.buttonMovePolygon.MouseHover += new System.EventHandler(this.buttonMovePolygon_MouseHover);
            // 
            // buttonMoveEdge
            // 
            this.buttonMoveEdge.BackColor = System.Drawing.Color.White;
            this.buttonMoveEdge.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.edge;
            this.buttonMoveEdge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveEdge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMoveEdge.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMoveEdge.ForeColor = System.Drawing.Color.Black;
            this.buttonMoveEdge.Location = new System.Drawing.Point(56, 3);
            this.buttonMoveEdge.Name = "buttonMoveEdge";
            this.buttonMoveEdge.Size = new System.Drawing.Size(47, 38);
            this.buttonMoveEdge.TabIndex = 7;
            this.buttonMoveEdge.TabStop = false;
            this.buttonMoveEdge.UseVisualStyleBackColor = false;
            this.buttonMoveEdge.Click += new System.EventHandler(this.buttonMoveEdge_Click);
            this.buttonMoveEdge.MouseHover += new System.EventHandler(this.buttonMoveEdge_MouseHover);
            // 
            // buttonMoveVertex
            // 
            this.buttonMoveVertex.BackColor = System.Drawing.Color.White;
            this.buttonMoveVertex.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.vertex;
            this.buttonMoveVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveVertex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMoveVertex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMoveVertex.ForeColor = System.Drawing.Color.Black;
            this.buttonMoveVertex.Location = new System.Drawing.Point(3, 3);
            this.buttonMoveVertex.Name = "buttonMoveVertex";
            this.buttonMoveVertex.Size = new System.Drawing.Size(47, 38);
            this.buttonMoveVertex.TabIndex = 6;
            this.buttonMoveVertex.TabStop = false;
            this.buttonMoveVertex.UseVisualStyleBackColor = false;
            this.buttonMoveVertex.Click += new System.EventHandler(this.buttonMoveVertex_Click);
            this.buttonMoveVertex.MouseHover += new System.EventHandler(this.buttonMoveVertex_MouseHover);
            // 
            // groupBoxDelete
            // 
            this.groupBoxDelete.Controls.Add(this.tableLayoutPanelDelete);
            this.groupBoxDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxDelete.Location = new System.Drawing.Point(3, 145);
            this.groupBoxDelete.Name = "groupBoxDelete";
            this.groupBoxDelete.Size = new System.Drawing.Size(166, 65);
            this.groupBoxDelete.TabIndex = 1;
            this.groupBoxDelete.TabStop = false;
            this.groupBoxDelete.Text = "Delete";
            // 
            // tableLayoutPanelDelete
            // 
            this.tableLayoutPanelDelete.ColumnCount = 3;
            this.tableLayoutPanelDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanelDelete.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelDelete.Controls.Add(this.buttonDeletePolygon, 0, 0);
            this.tableLayoutPanelDelete.Controls.Add(this.buttonDeleteRelation, 0, 0);
            this.tableLayoutPanelDelete.Controls.Add(this.buttonDeleteVertex, 0, 0);
            this.tableLayoutPanelDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDelete.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelDelete.Name = "tableLayoutPanelDelete";
            this.tableLayoutPanelDelete.RowCount = 1;
            this.tableLayoutPanelDelete.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDelete.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelDelete.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelDelete.Size = new System.Drawing.Size(160, 44);
            this.tableLayoutPanelDelete.TabIndex = 0;
            // 
            // buttonDeletePolygon
            // 
            this.buttonDeletePolygon.BackColor = System.Drawing.Color.White;
            this.buttonDeletePolygon.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.polygon;
            this.buttonDeletePolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeletePolygon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeletePolygon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeletePolygon.Location = new System.Drawing.Point(109, 3);
            this.buttonDeletePolygon.Name = "buttonDeletePolygon";
            this.buttonDeletePolygon.Size = new System.Drawing.Size(48, 38);
            this.buttonDeletePolygon.TabIndex = 6;
            this.buttonDeletePolygon.TabStop = false;
            this.buttonDeletePolygon.UseVisualStyleBackColor = false;
            this.buttonDeletePolygon.Click += new System.EventHandler(this.buttonDeletePolygon_Click);
            this.buttonDeletePolygon.MouseHover += new System.EventHandler(this.buttonDeletePolygon_MouseHover);
            // 
            // buttonDeleteRelation
            // 
            this.buttonDeleteRelation.BackColor = System.Drawing.Color.White;
            this.buttonDeleteRelation.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.relation;
            this.buttonDeleteRelation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteRelation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteRelation.Location = new System.Drawing.Point(56, 3);
            this.buttonDeleteRelation.Name = "buttonDeleteRelation";
            this.buttonDeleteRelation.Size = new System.Drawing.Size(47, 38);
            this.buttonDeleteRelation.TabIndex = 5;
            this.buttonDeleteRelation.TabStop = false;
            this.buttonDeleteRelation.UseVisualStyleBackColor = false;
            this.buttonDeleteRelation.Click += new System.EventHandler(this.buttonDeleteRelation_Click);
            this.buttonDeleteRelation.MouseHover += new System.EventHandler(this.buttonDeleteRelation_MouseHover);
            // 
            // buttonDeleteVertex
            // 
            this.buttonDeleteVertex.BackColor = System.Drawing.Color.White;
            this.buttonDeleteVertex.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.vertex;
            this.buttonDeleteVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteVertex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteVertex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteVertex.Location = new System.Drawing.Point(3, 3);
            this.buttonDeleteVertex.Name = "buttonDeleteVertex";
            this.buttonDeleteVertex.Size = new System.Drawing.Size(47, 38);
            this.buttonDeleteVertex.TabIndex = 3;
            this.buttonDeleteVertex.TabStop = false;
            this.buttonDeleteVertex.UseVisualStyleBackColor = false;
            this.buttonDeleteVertex.Click += new System.EventHandler(this.buttonDeleteVertex_Click);
            this.buttonDeleteVertex.MouseHover += new System.EventHandler(this.buttonDeleteVertex_MouseHover);
            // 
            // groupBoxAddRelation
            // 
            this.groupBoxAddRelation.Controls.Add(this.tableLayoutPanelAddRelation);
            this.groupBoxAddRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAddRelation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxAddRelation.Location = new System.Drawing.Point(3, 216);
            this.groupBoxAddRelation.Name = "groupBoxAddRelation";
            this.groupBoxAddRelation.Size = new System.Drawing.Size(166, 65);
            this.groupBoxAddRelation.TabIndex = 2;
            this.groupBoxAddRelation.TabStop = false;
            this.groupBoxAddRelation.Text = "Add relation";
            // 
            // tableLayoutPanelAddRelation
            // 
            this.tableLayoutPanelAddRelation.ColumnCount = 3;
            this.tableLayoutPanelAddRelation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelAddRelation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanelAddRelation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelAddRelation.Controls.Add(this.buttonVertical, 0, 0);
            this.tableLayoutPanelAddRelation.Controls.Add(this.buttonHorizontal, 0, 0);
            this.tableLayoutPanelAddRelation.Controls.Add(this.buttonAngle, 0, 0);
            this.tableLayoutPanelAddRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAddRelation.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelAddRelation.Name = "tableLayoutPanelAddRelation";
            this.tableLayoutPanelAddRelation.RowCount = 1;
            this.tableLayoutPanelAddRelation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAddRelation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelAddRelation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelAddRelation.Size = new System.Drawing.Size(160, 44);
            this.tableLayoutPanelAddRelation.TabIndex = 0;
            // 
            // buttonVertical
            // 
            this.buttonVertical.BackColor = System.Drawing.Color.White;
            this.buttonVertical.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.vertical;
            this.buttonVertical.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonVertical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVertical.Location = new System.Drawing.Point(109, 3);
            this.buttonVertical.Name = "buttonVertical";
            this.buttonVertical.Size = new System.Drawing.Size(48, 38);
            this.buttonVertical.TabIndex = 5;
            this.buttonVertical.TabStop = false;
            this.buttonVertical.UseVisualStyleBackColor = false;
            this.buttonVertical.Click += new System.EventHandler(this.buttonVertical_Click);
            this.buttonVertical.MouseHover += new System.EventHandler(this.buttonVertical_MouseHover);
            // 
            // buttonHorizontal
            // 
            this.buttonHorizontal.BackColor = System.Drawing.Color.White;
            this.buttonHorizontal.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.horizontal;
            this.buttonHorizontal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHorizontal.Location = new System.Drawing.Point(56, 3);
            this.buttonHorizontal.Name = "buttonHorizontal";
            this.buttonHorizontal.Size = new System.Drawing.Size(47, 38);
            this.buttonHorizontal.TabIndex = 4;
            this.buttonHorizontal.TabStop = false;
            this.buttonHorizontal.UseVisualStyleBackColor = false;
            this.buttonHorizontal.Click += new System.EventHandler(this.buttonHorizontal_Click);
            this.buttonHorizontal.MouseHover += new System.EventHandler(this.buttonHorizontal_MouseHover);
            // 
            // buttonAngle
            // 
            this.buttonAngle.BackColor = System.Drawing.Color.White;
            this.buttonAngle.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.angle;
            this.buttonAngle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAngle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAngle.Location = new System.Drawing.Point(3, 3);
            this.buttonAngle.Name = "buttonAngle";
            this.buttonAngle.Size = new System.Drawing.Size(47, 38);
            this.buttonAngle.TabIndex = 3;
            this.buttonAngle.TabStop = false;
            this.buttonAngle.UseVisualStyleBackColor = false;
            this.buttonAngle.Click += new System.EventHandler(this.buttonAngle_Click);
            this.buttonAngle.MouseHover += new System.EventHandler(this.buttonAngle_MouseHover);
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.tableLayoutPanelAdd);
            this.groupBoxAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAdd.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(166, 65);
            this.groupBoxAdd.TabIndex = 3;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "Add";
            // 
            // tableLayoutPanelAdd
            // 
            this.tableLayoutPanelAdd.ColumnCount = 3;
            this.tableLayoutPanelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanelAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelAdd.Controls.Add(this.buttonAddVertex, 0, 0);
            this.tableLayoutPanelAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAdd.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanelAdd.Name = "tableLayoutPanelAdd";
            this.tableLayoutPanelAdd.RowCount = 1;
            this.tableLayoutPanelAdd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAdd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelAdd.Size = new System.Drawing.Size(160, 44);
            this.tableLayoutPanelAdd.TabIndex = 0;
            // 
            // buttonAddVertex
            // 
            this.buttonAddVertex.BackColor = System.Drawing.Color.White;
            this.buttonAddVertex.BackgroundImage = global::Project1_Polygon_Editor.Properties.Resources.vertex;
            this.buttonAddVertex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddVertex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddVertex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddVertex.Location = new System.Drawing.Point(3, 3);
            this.buttonAddVertex.Name = "buttonAddVertex";
            this.buttonAddVertex.Size = new System.Drawing.Size(47, 38);
            this.buttonAddVertex.TabIndex = 0;
            this.buttonAddVertex.TabStop = false;
            this.buttonAddVertex.UseCompatibleTextRendering = true;
            this.buttonAddVertex.UseVisualStyleBackColor = false;
            this.buttonAddVertex.Click += new System.EventHandler(this.buttonAddVertex_Click);
            this.buttonAddVertex.MouseHover += new System.EventHandler(this.buttonAddVertex_MouseHover);
            // 
            // focusLabel
            // 
            this.focusLabel.AutoSize = true;
            this.focusLabel.Location = new System.Drawing.Point(3, 284);
            this.focusLabel.Name = "focusLabel";
            this.focusLabel.Size = new System.Drawing.Size(0, 17);
            this.focusLabel.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1182, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawingToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // drawingToolStripMenuItem
            // 
            this.drawingToolStripMenuItem.Name = "drawingToolStripMenuItem";
            this.drawingToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.drawingToolStripMenuItem.Text = "Drawing";
            this.drawingToolStripMenuItem.Click += new System.EventHandler(this.drawingToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Polygon_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Polygon_Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygon_Editor";
            this.SizeChanged += new System.EventHandler(this.Polygon_Editor_SizeChanged);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanelMenu.ResumeLayout(false);
            this.tableLayoutPanelMenu.PerformLayout();
            this.groupBoxMove.ResumeLayout(false);
            this.tableLayoutPanelMove.ResumeLayout(false);
            this.groupBoxDelete.ResumeLayout(false);
            this.tableLayoutPanelDelete.ResumeLayout(false);
            this.groupBoxAddRelation.ResumeLayout(false);
            this.tableLayoutPanelAddRelation.ResumeLayout(false);
            this.groupBoxAdd.ResumeLayout(false);
            this.tableLayoutPanelAdd.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxMove;
        private System.Windows.Forms.GroupBox groupBoxDelete;
        private System.Windows.Forms.GroupBox groupBoxAddRelation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAddRelation;
        private System.Windows.Forms.Button buttonMovePolygon;
        private System.Windows.Forms.Button buttonMoveEdge;
        private System.Windows.Forms.Button buttonMoveVertex;
        private System.Windows.Forms.Button buttonDeletePolygon;
        private System.Windows.Forms.Button buttonDeleteRelation;
        private System.Windows.Forms.Button buttonDeleteVertex;
        private System.Windows.Forms.Button buttonVertical;
        private System.Windows.Forms.Button buttonHorizontal;
        private System.Windows.Forms.Button buttonAngle;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAdd;
        private System.Windows.Forms.Button buttonAddVertex;
        private System.Windows.Forms.Label focusLabel;
    }
}

