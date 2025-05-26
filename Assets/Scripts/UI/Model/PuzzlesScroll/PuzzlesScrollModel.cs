namespace Jigsawgram.UI.View
{
    public class PuzzlesScrollModel : IPuzzlesScrollViewModel
    {
        public IPuzzlesScrollItemViewModel[] ItemModels { get; }

        public PuzzlesScrollModel(IPuzzlesScrollItemViewModel[] itemModels)
        {
            ItemModels = itemModels;
        }
    }
}
