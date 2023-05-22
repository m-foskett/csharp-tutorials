using System;
using System.Linq;
using System.Collections.Generic;

public class Song
{
    private string name;
    public Song NextSong { get; set; }

    public Song(string _name)
    {
        this.name = _name;
    }

    public bool IsInRepeatingPlaylist()
    {
        // Initialise an empty playlist using a HashSet<Song>
        // string[] playlist = { };
        HashSet<Song> playlist = new HashSet<Song>() { this };
        // Initialise a pointer to nextsong
        Song next = this.NextSong;
        // Whilst not pointing to end of playlist
        while (next != null)
        {
            // Check if the playlist already contains the next song name in the playlist (repeating)
            if (playlist.Contains(next))
            {
                // Repeating; return true
                return true;
            }
            // Add the next song name to the playlist
            playlist.Add(next);
            // Update the next song to check
            next = next.NextSong;
        }
        // Not repeating; return false
        return false;
    }

    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;

        Console.WriteLine(first.IsInRepeatingPlaylist());
    }
}
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// FLOYDS TORTOISE AND HARE CYCLE DETECTION ALGORITHM
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// public bool IsRepeatingPlaylist()
// {
//     var tortoise = this;
//     var hare     = NextSong;
//     (AKA slow/fast)
//     while (tortoise is not null && hare is not null)
//     {
//         if (ReferenceEquals(tortoise, hare))
//             return true;

//         tortoise = tortoise.NextSong;
//         hare     = hare.NextSong?.NextSong; // Twice as fast.
//     }

//     return false;
// }
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

// if (playlist.Contains(next.name))
// Array.Sort(playlist);
// if (Array.BinarySearch(playlist, next.name) < 0)
// if (Array.Exists(playlist, song => song == (next.name)))
// playlist = playlist.Append(current.name).ToArray();