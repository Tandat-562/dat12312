using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.Service;
using DAL.Model;
using System.Linq;
namespace QUANLYCHITIEU
{
    public partial class Form2 : Form
    {
        private readonly ThuNhapService _thuNhapService;
        private List<ThuNhap> thuNhapList = new List<ThuNhap>();
        private readonly int _userId;
        private readonly ChiTieuService _chiTieuService;
   


        public Form2(int userId)
        {
            InitializeComponent();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            _userId = userId;
            _thuNhapService = new ThuNhapService();
            _chiTieuService = new ChiTieuService();
            // Gán sự kiện cho các nút
            btnLuuthunhap.Click += btnLuuthunhap_Click;
            btnSuathunhap.Click += btnSuathunhap_Click;
            btnXoathunhap.Click += btnXoathunhap_Click;
            btne.Click += btne_Click;

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dgv2.Columns.Clear(); // Đảm bảo xóa các cột hiện có
            dgv2.Columns.Add("SoTien", "Số Tiền");
            dgv2.Columns.Add("NgayThu", "Ngày Thu");
            dgv2.Columns.Add("GhiChu", "Ghi Chú");
            dgv2.CellClick += dgv2_CellClick;
        }

        private void btnLuuthunhap_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtsotienthunhap.Text, out decimal soTien))
            {
                try
                {
                    _thuNhapService.AddThuNhap(_userId, soTien, dtp2.Value, txtchichuthunhap.Text);
                    LoadThuNhapData();
                    ClearThuNhapInputs();
                    UpdateTongChiTieu();
                    UpdateTongThuNhapTruTongChiTieu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Số tiền không hợp lệ!");
            }

        }

        private void ClearThuNhapInputs()
        {
            txtsotienthunhap.Clear();
            txtchichuthunhap.Clear();
            dtp2.Value = DateTime.Now;
        }

        private void btnSuathunhap_Click(object sender, EventArgs e)
        {
            if (dgv2.CurrentRow != null)
            {
                int index = dgv2.CurrentRow.Index;
                if (decimal.TryParse(txtsotienthunhap.Text, out decimal soTien))
                {
                    try
                    {
                        thuNhapList[index].SoTien = soTien;
                        thuNhapList[index].NgayThu = dtp2.Value;
                        thuNhapList[index].GhiChu = txtchichuthunhap.Text;

                        LoadDataGridViewThuNhap();
                        ClearThuNhapInputs();
                        LoadThuNhapData();
                        UpdateTongChiTieu();
                        UpdateTongThuNhapTruTongChiTieu();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Số tiền không hợp lệ!");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một khoản thu nhập để sửa!");
            }
        }

        private void btnXoathunhap_Click(object sender, EventArgs e)
        {
            if (dgv2.CurrentRow != null)
            {
                int index = dgv2.CurrentRow.Index;

                // Kiểm tra lại nếu chỉ mục nằm trong phạm vi danh sách
                if (index >= 0 && index < thuNhapList.Count)
                {
                    var thuNhap = thuNhapList[index];

                    // Xóa khoản thu nhập trong cơ sở dữ liệu
                    // Xóa khoản thu nhập trong cơ sở dữ liệu
                    _thuNhapService.DeleteThuNhap(thuNhap.Id.GetValueOrDefault());

                    // Xóa khỏi danh sách và cập nhật lại DataGridView
                    thuNhapList.RemoveAt(index);
                    LoadThuNhapData(); // Load lại dữ liệu từ cơ sở dữ liệu và cập nhật DataGridView
                    ClearThuNhapInputs();
                    UpdateTongChiTieu();
                    UpdateTongThuNhapTruTongChiTieu();
                }
                else
                {
                    MessageBox.Show("Không thể xóa mục đã chọn. Vui lòng thử lại.");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một khoản thu nhập để xóa!");
            }
        }

        private void LoadDataGridViewThuNhap()
        {
            dgv2.Rows.Clear();
            foreach (var thuNhap in thuNhapList)
            {
                dgv2.Rows.Add(thuNhap.SoTien?.ToString("N0") ?? "0", thuNhap.NgayThu.ToString("dd/MM/yyyy"), thuNhap.GhiChu);
            }
        }

        private void LoadThuNhapData()
        {
            thuNhapList = _thuNhapService.GetThuNhapByUser(_userId);
            LoadDataGridViewThuNhap();

            // Hiển thị tổng thu nhập
            decimal? totalThuNhap = _thuNhapService.GetTotalThuNhap(_userId);
            txttst.Text = totalThuNhap.HasValue ? totalThuNhap.Value.ToString("N0") : "0";
            UpdateTongChiTieu();
            UpdateTongThuNhapTruTongChiTieu();
        }

        private void btne_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(_userId);
            this.Hide(); // Ẩn Form2 trước khi mở Form1
            form1.ShowDialog(); // Hiện Form1 như một dialog
            this.Show(); // Hiện lại Form2 khi Form1 đóng
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            LoadThuNhapData(); // Tải lại dữ liệu thu nhập từ dịch vụ
            LoadDataGridViewThuNhap();
            UpdateTongThuNhapTruTongChiTieu();
            UpdateTongChiTieu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv2.Rows[e.RowIndex];
                txtsotienthunhap.Text = row.Cells["SoTien"].Value?.ToString();
                dtp2.Value = DateTime.TryParse(row.Cells["NgayThu"].Value?.ToString(), out DateTime ngayThu)
                             ? ngayThu : DateTime.Now;
                txtchichuthunhap.Text = row.Cells["GhiChu"].Value?.ToString();
            }
        }

        private void txtttn_TextChanged(object sender, EventArgs e)
        {
            decimal tongSoTien = TinhTongSoTienChiTieu(); // Gọi phương thức tính tổng

            // Hiển thị tổng số tiền trong txtttn
            txtttn.Text = tongSoTien.ToString("N0"); // Định dạng hiển thị cho dễ đọc (VD: 1,000,000)
        }
        private void UpdateTongChiTieu() // Hàm cập nhật tổng chi tiêu
        {
            decimal tongSoTienChiTieu = TinhTongSoTienChiTieu();
            txtttn.Text = tongSoTienChiTieu.ToString("N0"); // Định dạng hiển thị cho dễ đọc
        }
        private decimal TinhTongSoTienChiTieu()
        {
            var chiTieuService = new ChiTieuService();
            var chiTieuList = chiTieuService.GetAllChiTieu();
            if (chiTieuList == null)
            {
                return 0; // Hoặc xử lý khác
            }

            decimal tongSoTien = chiTieuList.Sum(ct => ct.SoTien ?? 0); // Tính tổng số tiền
            return tongSoTien;
            
        }
        private ChiTieuService chiTieuService = new ChiTieuService(); // Khởi tạo ChiTieuService

        private void txtstcl_TextChanged(object sender, EventArgs e)
        {
            UpdateTongThuNhapTruTongChiTieu();
        }
        private void UpdateTongThuNhapTruTongChiTieu()
        {
            // Lấy tổng thu nhập
            decimal? totalThuNhap = _thuNhapService.GetTotalThuNhap(_userId);
            decimal totalChiTieu = TinhTongSoTienChiTieu(); // Lấy tổng chi tiêu

            // Tính chênh lệch
            decimal soTienconlai = (totalThuNhap ?? 0) - totalChiTieu;

            // Hiển thị kết quả trong txtstcl
            txtstcl.Text = soTienconlai.ToString("N0"); // Định dạng hiển thị cho dễ đọc
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
