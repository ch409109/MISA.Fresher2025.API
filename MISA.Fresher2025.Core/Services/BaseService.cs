using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Services
{
    public class BaseService<T>
    {
        public bool ValidateData(T entity)
        {
            // Thực hiện các bước kiểm tra dữ liệu chung cho tất cả các thực thể
            // Ví dụ: Kiểm tra dữ liệu không được null, định dạng đúng, v.v.
            if (entity == null)
            {
                return false;
            }
            // Thêm các quy tắc kiểm tra dữ liệu khác tại đây
            return true; // Trả về true nếu dữ liệu hợp lệ
        }
    }
}
