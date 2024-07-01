using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Components.PagenationComponent
{
    internal class PagenationService
    {
        private int MaxPage = 0;
        int PageIndex = 1;
        private int PerPageCount = 6; // 每一頁有多少筆
        public PagenationService(int ProductCount)
        {
            // 計算總共要有幾頁
            if (ProductCount % PerPageCount == 0)
            {
                this.MaxPage = ProductCount / PerPageCount;
            }
            else
            {
                this.MaxPage = (ProductCount / PerPageCount) + 1;
            }
        }


        /// <summary>
        ///  頁面切換，當前端呼叫該方法時，會根據傳入的行為回傳所在的頁面位置。若 Item1為true 則代表同時需要換頁 若為false 則只需要回傳當前頁碼
        /// </summary>
        /// <param name="type">跳頁的行為</param>
        /// <returns>回傳兩個結果。 Item1為顯示是否需要換頁 Item2為顯示當前頁碼</returns>
        public (bool, int) ChangePage(PageAction type)
        {

            bool canChangePage = false;


            switch (type)
            {
                case PageAction.Previous:

                    if (PageIndex - 1 > 0)
                    {
                        PageIndex--;
                        if (PageIndex % 10 == 0)
                        {
                            canChangePage = true;
                        }
                        else
                        {
                            canChangePage = false;
                        }
                    }

                    break;

                case PageAction.Next:
                    if (PageIndex + 1 <= MaxPage)
                    {
                        PageIndex++;
                        //Console.WriteLine(PageIndex.ToString());
                        if (PageIndex % 10 != 1)
                        {
                            canChangePage = false;

                        }
                        else
                        {
                            canChangePage = true;
                        }
                    }

                    break;
            }
            return (canChangePage, PageIndex);
        }
        /// <summary>
        ///  根據傳入的行為進行頁面的更新，傳回一包要跳頁的List<int> 給前端重新渲染新的頁碼
        /// </summary>
        /// <returns>傳回一包頁碼List</returns>
        public List<int> RenderPages(PageAction type)
        {
            List<int> pages = new List<int>();
            if (type == PageAction.Init)
            {
                pages.Clear();
                if (MaxPage > 10)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        pages.Add(i);
                    }
                }
                else
                {
                    for (int i = 1; i <= MaxPage; i++)
                    {
                        pages.Add(i);
                    }
                }
            }
            else if (type == PageAction.Previous)
            {
                pages.Clear();
                for (int i = PageIndex - 9; i <= PageIndex; i++)
                {
                    pages.Add(i);
                }
            }
            else
            {
                pages.Clear();
                if (MaxPage - PageIndex >= 10)
                {
                    for (int i = PageIndex; i <= PageIndex + 9; i++)
                    {
                        pages.Add(i);
                    }
                }
                else
                {
                    for (int i = PageIndex; i <= MaxPage; i++)
                    {
                        pages.Add(i);
                    }
                }
            }
            return pages;
        }

        /// <summary>
        /// 前端指定要跳轉到哪一頁
        /// </summary>
        /// <param name="pageNumber">傳入當前跳轉的頁碼</param>
        public void ChangePageNumber(int pageNumber)
        {
            this.PageIndex = pageNumber;
        }
    }
}
