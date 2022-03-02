using PixSmith.MicroServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixSmith.MicroServices.Poc.AsyncAwait.Context
{
    internal static class AsyncAwaitContext
    {
        public static Artist[] Artists = new[]
            {
                new Artist
                {
                    Name = "test1234dddddddddddddddddddddd",
                    Discography = new System.Collections.Generic.List<Record>
                    {
                        new Record
                        {
                            Name = "record1ForArtist1"
                        },
                        new Record
                        {
                            Name = "record2ForArtist1"
                        },
                        new Record
                        {
                            Name = "record3ForArtist1"
                        }
                    }
                },
                 new Artist
                {
                    Name = "test1235sdafsdd",
                    Discography = new System.Collections.Generic.List<Record>
                    {
                        new Record
                        {
                            Name = "record1ForArtist2"
                        },
                        new Record
                        {
                            Name = "record2ForArtist2"
                        },
                        new Record
                        {
                            Name = "record3ForArtist2"
                        }
                    }
                },
                  new Artist
                {
                    Name = "test1236ffff",
                    Discography = new System.Collections.Generic.List<Record>
                    {
                        new Record
                        {
                            Name = "record1ForArtist3"
                        },
                        new Record
                        {
                            Name = "record2ForArtist3"
                        },
                        new Record
                        {
                            Name = "record3ForArtist3"
                        }
                    }
                }
            };
    }
}
