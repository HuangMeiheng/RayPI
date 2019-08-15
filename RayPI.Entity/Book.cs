﻿namespace RayPI.Entity
{
    ///<summary>
    ///
    ///</summary>
    public partial class Book : EntityBase
    {
        /// <summary>
        /// Desc:书名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Title { get; set; }

        /// <summary>
        /// Desc:作者
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Writer { get; set; }

    }
}
