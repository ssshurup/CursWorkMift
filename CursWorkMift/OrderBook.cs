//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursWorkMift
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderBook
    {
        public int id { get; set; }
        public Nullable<int> idOrder { get; set; }
        public Nullable<int> idBook { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
