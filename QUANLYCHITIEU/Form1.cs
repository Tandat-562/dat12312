using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS.Service;
using DAL.Model;

namespace QUANLYCHITIEU
{
    public partial class Form1 : Form
    {
        private List<ChiTieu> chiTieuList = new List<ChiTieu>();
        private ChiTieuService _chiTieuService;
        private int _userId;
        private ThuNhapService _thuNhapService;
        
        public Form1(int userId)
        {
            InitializeComponent();
            // Thiết lập sự kiện cho các nút
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            btnThemDM.Click += btnThemDM_Click;
            btnXoaDM.Click += btnXoaDM_Click;
            btnLoad.Click += btnLoad_Click;

            // Thiết lập các cột cho DataGridView
            dgv1.Columns.Add("LoaiChiTieu", "Tên mặt hàng");
            dgv1.Columns.Add("DanhMuc", "Danh mục");
            dgv1.Columns.Add("SoTien", "Số Tiền");
            dgv1.Columns.Add("NgayChi", "Ngày Chi");
            dgv1.Columns.Add("MoTa", "Mô Tả");

            dgv1.CellClick += dgv1_CellClick;

            _chiTieuService = new ChiTieuService();
            _userId = userId;
            _thuNhapService = new ThuNhapService();
            LoadDataGridView();
            LoadDanhMuc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
           
            if (!decimal.TryParse(txtSotien.Text, out decimal soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }
            decimal tongChiTieuHienTai = TinhTongSoTienChiTieu();
            decimal? tongThuNhap = _thuNhapService.GetTotalThuNhap(_userId);// Tạo mới chi tiêu
            var chiTieu = new ChiTieu
            {
                LoaiChiTieu = txtLoaichitieu.Text,
                DanhMucID = (int)txtDM.SelectedValue, // Lấy ID danh mục
                SoTien = soTien,
                NgayChi = dtpNgayChi.Value,
                MoTa = rtb1.Text,
                UserId = _userId
            };

            _chiTieuService.AddChiTieu(_userId, txtLoaichitieu.Text, (int)txtDM.SelectedValue, soTien, dtpNgayChi.Value, rtb1.Text);

            LoadDataGridView(); // Cập nhật DataGridView
            ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow != null && dgv1.CurrentRow.Index >= 0)
            {
                int chiTieuId = chiTieuList[dgv1.CurrentRow.Index].ChiTieuID;

                if (!decimal.TryParse(txtSotien.Text, out decimal soTien))
                {
                    MessageBox.Show("Số tiền không hợp lệ!");
                    return;
                }
                // Cập nhật thông tin chi tiêu
                var chiTieu = new ChiTieu
                {
                    ChiTieuID = chiTieuId,
                    LoaiChiTieu = txtLoaichitieu.Text,
                    DanhMucID = (int)txtDM.SelectedValue,
                    SoTien = soTien,
                    NgayChi = dtpNgayChi.Value,
                    MoTa = rtb1.Text,
                    UserId = _userId
                };

                _chiTieuService.UpdateChiTieu(chiTieuId, _userId, txtLoaichitieu.Text, (int)txtDM.SelectedValue, soTien, dtpNgayChi.Value, rtb1.Text);

                LoadDataGridView();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Hãy chọn một chi tiêu để sửa!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow != null && dgv1.CurrentRow.Index >= 0)
            {
                int chiTieuId = chiTieuList[dgv1.CurrentRow.Index].ChiTieuID;
                _chiTieuService.DeleteChiTieu(chiTieuId, _userId);
                LoadDataGridView();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Hãy chọn một chi tiêu để xóa!");
            }
        }

        private void LoadDataGridView()
        {
            dgv1.Rows.Clear();
            chiTieuList = _chiTieuService.GetChiTieuByUser(_userId);

            foreach (var chiTieu in chiTieuList)
            {
                dgv1.Rows.Add(chiTieu.LoaiChiTieu, chiTieu.DanhMuc?.TenDanhMuc, chiTieu.SoTien, chiTieu.NgayChi, chiTieu.MoTa);
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv1.Rows[e.RowIndex];

                txtLoaichitieu.Text = row.Cells["LoaiChiTieu"].Value?.ToString();
                txtSotien.Text = row.Cells["SoTien"].Value?.ToString();
                rtb1.Text = row.Cells["MoTa"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayChi"].Value?.ToString(), out DateTime ngayChi))
                {
                    dtpNgayChi.Value = ngayChi;
                }

                // Tìm và chọn DanhMuc trong ComboBox
                string danhMuc = row.Cells["DanhMuc"].Value?.ToString();
                if (!string.IsNullOrEmpty(danhMuc)) // Kiểm tra xem danh mục có null hoặc rỗng không
                {
                    if (txtDM.Items.Contains(danhMuc))
                    {
                        txtDM.SelectedItem = danhMuc; // Chọn mục nếu có trong danh sách
                    }
                    else
                    {
                        txtDM.Text = danhMuc; // Hoặc gán text nếu không có trong danh sách
                    }
                }
                else
                {
                    txtDM.SelectedItem = -1; // Đặt ComboBox về giá trị null nếu danh mục không có
                }
                if (txtDM.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục!");
                    return;
                }

            }
        }
            private void ClearInputs()
        {
            txtLoaichitieu.Clear();
            txtSotien.Clear();
            rtb1.Clear();
            dtpNgayChi.Value = DateTime.Now;
            txtDM.SelectedIndex = -1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LoadDanhMuc()
        {
            var danhMucService = new DanhMucService();
            var danhMucList = danhMucService.GetAllDanhMuc();

            
            txtDM.DataSource = danhMucList;
            txtDM.DisplayMember = "TenDanhMuc";
            txtDM.ValueMember = "DanhMucID";
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            string newDanhMuc = txtDM.Text.Trim();

            if (!string.IsNullOrEmpty(newDanhMuc))
            {
                // Kiểm tra nếu danh mục đã tồn tại
                var danhMucService = new DanhMucService();
                var danhMucList = danhMucService.GetAllDanhMuc();

                if (!danhMucList.Any(dm => dm.TenDanhMuc == newDanhMuc))
                {
                    // Thêm danh mục mới vào cơ sở dữ liệu
                    var danhMucMoi = new DanhMuc { TenDanhMuc = newDanhMuc };
                    danhMucService.AddDanhMuc(newDanhMuc);

                    // Cập nhật lại danh sách và gán lại DataSource
                    danhMucList = danhMucService.GetAllDanhMuc();
                    txtDM.DataSource = danhMucList;
                    txtDM.DisplayMember = "TenDanhMuc";
                    txtDM.ValueMember = "DanhMucID";
                    LoadDanhMuc();       // Cập nhật lại ComboBox
                    LoadDataGridView();
                    MessageBox.Show("Danh mục đã được thêm thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Danh mục này đã tồn tại!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập danh mục hợp lệ!", "Thông báo");
            }
        }


        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            var selectedDanhMuc = txtDM.SelectedItem as DanhMuc; // Chọn mục đã chọn là kiểu DanhMuc
            if (selectedDanhMuc != null)
            {
                var danhMucService = new DanhMucService();
                danhMucService.DeleteDanhMuc(selectedDanhMuc.DanhMucID); // Xóa danh mục khỏi CSDL
                LoadDanhMuc();       // Cập nhật lại ComboBox
                LoadDataGridView();
                MessageBox.Show("Danh mục đã được xóa thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa!", "Thông báo");
            }
        }


        private void btnf2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_userId);
            form2.Show();
            
           

        }
        private decimal TinhTongSoTienChiTieu()
        {
            var chiTieuService = new ChiTieuService();
            
            var chiTieuList = _chiTieuService.GetChiTieuByUser(_userId);
            decimal tongSoTien = chiTieuList.Sum(ct => ct.SoTien ?? 0); // Tính tổng số tiền
            return tongSoTien;

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadDataGridView();
            MessageBox.Show("Dữ liệu đã được tải lại!", "Thông báo");
        }
    }
}
