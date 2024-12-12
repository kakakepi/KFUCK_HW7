using System.Runtime.CompilerServices;
namespace Lab6{
    class Song{
    string name;
    string author;
    Song prev;
    public Song(){}
    public Song(string name, string author)
    {
        this.name = name;
        this.author = author;
    }
    public Song(string name, string author, Song prev)
    {
        this.name = name;
        this.author = author;
        this.prev = prev;
    }
    public string Title()
    {
        if (author == null){
            return "Автор не указан";
        }
        else if (name == null){
            return "Название песни не указано";
        }
        return $"Название песни: {name}\n" +
                $"Автор песни: {author}";
    }
    public override bool Equals(object d)
    {
        if (d is Song otherSong)
        {
            return name == otherSong.name && author == otherSong.author;
        }
            return false;
    }
    }
}