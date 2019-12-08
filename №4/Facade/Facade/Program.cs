using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Musician
    {
        protected string Name { get; }

        public Musician(string someName)
        {
            Name = someName;
        }
    }

    class Vocalist : Musician
    {
        public Vocalist(string someName) : base(someName) { }

        public void singCouplet(int coupletNumber)
        {
            Console.WriteLine("{0} singing {1} couplet of song", Name, coupletNumber);
        }

        public void singChorus()
        {
            Console.WriteLine("{0} singing chorus of song", Name);
        }
    }

    class GuitarPlayer : Musician
    {
        public GuitarPlayer(string someName) : base(someName) { }

        public void startPlaying()
        {
            Console.WriteLine("{0} start plaing guitar part", Name);
        }

        public void stopPlaying()
        {
            Console.WriteLine("{0} stop plaing guitar part", Name);
        }

        public void playSolo()
        {
            Console.WriteLine("{0} plaing solo part", Name);
        }
    }

    class Drummer : Musician
    {
        public Drummer(string someName) : base(someName) { }

        public void startPlaying()
        {
            Console.WriteLine("{0} start plaing drumms part", Name);
        }

        public void stopPlaying()
        {
            Console.WriteLine("{0} stop plaing drumms part", Name);
        }
    }

    class MusicBand
    {
        Vocalist someVocalist = new Vocalist("Tom");
        GuitarPlayer someGuitarPlayer = new GuitarPlayer("Ross");
        Drummer someDrummer = new Drummer("Bob");

        public void palySong()
        {
            someGuitarPlayer.startPlaying();
            someDrummer.startPlaying();
            someVocalist.singCouplet(1);
            someVocalist.singChorus();
            someGuitarPlayer.playSolo();
            someVocalist.singCouplet(2);
            someGuitarPlayer.stopPlaying();
            someDrummer.stopPlaying();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicBand someBand = new MusicBand();
            someBand.palySong();

            Console.ReadLine();
        }
    }
}
