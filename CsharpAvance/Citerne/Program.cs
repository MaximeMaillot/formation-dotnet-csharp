using Citerne.Classes;

List<Watertank> watertanks = new List<Watertank>
{
    new Watertank(10, 20, 10),
    new Watertank(5, 10, 10)
};
watertanks[0].GetTotalWeight();
watertanks[1].GetTotalWeight();
watertanks[0].ShowWaterLevel();
watertanks[1].ShowWaterLevel();
Watertank.ShowTotalWaterLevel();
watertanks[0].Fill(11);
watertanks[1].Drain(11);
watertanks[0].ShowWaterLevel();
watertanks[1].ShowWaterLevel();
Watertank.ShowTotalWaterLevel();