using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace BoxStation
{
    public partial class ReservedList : ContentPage
    {
        public ReservedList()
        {
            InitializeComponent();

            List<Data.Boxes> dataSource = new List<Data.Boxes>();
            foreach (var item in Data.Resources.Boxes)
            {
                dataSource.Add(new Data.Boxes(item.bst, item.bxn, item.isO, item.isP,item.stf,item.pw,item.date));
            }

            CollectionView reservedListContainerView = new CollectionView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Padding= new Extents(10, 100, 100, 10),
                ItemsSource = dataSource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    return new box.CustomReservedList();
                }),

            };
            reservedList.Add(reservedListContainerView);
        }

        
    }
}
