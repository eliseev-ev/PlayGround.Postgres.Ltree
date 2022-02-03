using Microsoft.EntityFrameworkCore;
using PlayGround.Core6_0.PostgreTree;


using (var dbContext = new DataContext())
{
    var files = dbContext.Files.ToList();
    dbContext.Files.RemoveRange(files);
    dbContext.SaveChanges();

    var file1 = new PlayGround.Core6_0.PostgreTree.File
    {
        Name = "TOP",
        Path = new Microsoft.EntityFrameworkCore.LTree("TOP"),
        Guid = Guid.NewGuid()
    };

    var file2 = new PlayGround.Core6_0.PostgreTree.File
    {
        Name = "SUB",
        Path = new Microsoft.EntityFrameworkCore.LTree("TOP.1"),
        Guid = Guid.NewGuid()
    };


    var file3 = new PlayGround.Core6_0.PostgreTree.File
    {
        Name = "SUB1",
        Path = new Microsoft.EntityFrameworkCore.LTree("TOP.1.1"),
        Guid = Guid.NewGuid()
    };

    var file4 = new PlayGround.Core6_0.PostgreTree.File
    {
        Name = "SUB12",
        Path = new Microsoft.EntityFrameworkCore.LTree("TOP.1.2"),
        Guid = Guid.NewGuid()
    };

    var file5 = new PlayGround.Core6_0.PostgreTree.File
    {
        Name = "SUB121",
        Path = new Microsoft.EntityFrameworkCore.LTree("TOP.1.2.1"),
        Guid = Guid.NewGuid()
    };

    var file6 = new PlayGround.Core6_0.PostgreTree.File
    {
        Name = "SUB122",
        Path = new Microsoft.EntityFrameworkCore.LTree("TOP.1.2.1"),
        Guid = Guid.NewGuid()
    };

    var file7 = new PlayGround.Core6_0.PostgreTree.File
    {
        Name = "Unknown",
        Path = new Microsoft.EntityFrameworkCore.LTree("unknown.1.2.1"),
        Guid = Guid.NewGuid()
    };

    dbContext.AddRange(
        file1,
        file2,
        file2,
        file3,
        file4,
        file5,
        file6,
        file7);

    dbContext.SaveChanges();
};


using (var dbContext = new DataContext())
{
    var file = dbContext.Files.First(x => x.Name == "SUB");
    // получаем все дочерние элементы
    var files = dbContext.Files.Where(x => x.Path.IsDescendantOf(file.Path)).ToList();

    // получаем всех дочек без текущего
    var filesOnlySub = dbContext.Files.Where(x => x.Path.IsDescendantOf(file.Path) && file.Path.Index(x.Path) != 0 ).ToList();
};