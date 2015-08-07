using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class PostDecorator
    {
        private Post post;
        public PostDecorator(Post post)
        {
            this.post = post;
        }

        override public string ToString()
        {
            return post.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код должности")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return post.id;
            }
            set
            {
                post.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Название должности")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название должности")]
        public string PostName
        {
            get
            {
                return post.PostName;
            }
            set
            {
                post.PostName = value;
            }
        }


        [System.ComponentModel.DisplayName("Название категории персонала")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название категории персонала, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Category Category
        {
            get
            {
                return post.Category;
            }
            set
            {
                post.Category = value;
            }
        }


        [System.ComponentModel.DisplayName("Новая категория персонала")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название новой категории персонала, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Category NewCategory
        {
            get
            {
                return post.NewCategory;
            }
            set
            {
                post.NewCategory = value;
            }
        }


        [System.ComponentModel.DisplayName("Название группы должностей")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название группы должностей, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostGroupEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.PostGroup PostGroup
        {
            get
            {
                return post.PostGroup;
            }
            set
            {
                post.PostGroup = value;
            }
        }

        [System.ComponentModel.DisplayName("Название категории для ВПО-2")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название категории для ВПО-2, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategoryVPOEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.CategoryVPO CategoryVPO
        {
            get
            {
                return post.CategoryVPO;
            }
            set
            {
                post.CategoryVPO = value;
            }
        }

        [System.ComponentModel.DisplayName("Название категории для ЗП-образования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название категории для ЗП-образования, к которой относится должность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.CategoryZPEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.CategoryZP CategoryZP
        {
            get
            {
                return post.CategoryZP;
            }
            set
            {
                post.CategoryZP = value;
            }
        }

        [System.ComponentModel.DisplayName("Руководитель")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководящая должность")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        //[System.ComponentModel.TypeConverter
        public bool ManagerBit
        {
            get
            {
                return post.ManagerBit;
            }
            set
            {
                post.ManagerBit = value;
            }
        }

        [System.ComponentModel.DisplayName("Профессиональный уровень")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Профессиональный уровень должности")]
        [System.ComponentModel.Editor(typeof(PKCategoryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public PKCategory PKCategory
        {
            get
            {
                return post.PKCategory;

            }
            set
            {
                post.PKCategory = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ министерства")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ министерства")]
        [System.ComponentModel.Editor(typeof(GlobalPrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public GlobalPrikaz GlobalPrikaz
        {
            get
            {
                return post.GlobalPrikaz;
            }
            set
            {
                post.GlobalPrikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид должности")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Вид должности")]
        [System.ComponentModel.Editor(typeof(PostTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public PostType PostType
        {
            get
            {
                return post.PostType;

            }
            set
            {
                post.PostType = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены должности")]
        [System.ComponentModel.Category("Параметры отмены")]
        [System.ComponentModel.Description("Дата отмены должности")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(post.DateEnd);
            }
            set
            {
                post.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Примечание")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Комментарий к должности")]
        public string Comment
        {
            get
            {
                return post.Comment;
            }
            set
            {
                post.Comment = value;
            }
        }

        [System.ComponentModel.DisplayName("Код должности")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код должности")]
        public string PostCode
        {
            get
            {
                return post.PostCode;
            }
            set
            {
                post.PostCode = value;
            }
        }

    }
}
