using Microsoft.EntityFrameworkCore;
using TheSecretGarden.Enum;

namespace TheSecretGarden.Models
{
    public static class SeedBookData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                //Look for any books
                if(context.Books.Any())
                {
                    return; // DB has been seeded
                }
                context.Books.AddRange(
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book1.jpg",
                        Title = "Jane Eyre",
                        Author = "Charlotte Bronte",
                        Price = 75.00,
                        Description = "This book takes us on the emotional journey of Jane Eyre. We witness her courageous spirit as she navigates life's challenges, delving into her growth, love for the enigmatic Mr. Rochester, and unwavering moral compass. With introspective depth, the novel dissects Jane's evolution and captivates readers with a depth previously reserved for poetry. While tackling social criticism and morality, the novel's exploration of class, sexuality, religion, and proto-feminism through Jane's independent spirit solidifies its position as a timeless masterpiece.",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book2.jpg",
                        Title = "Frankenstein",
                        Author = "Mary Shelley",
                        Price = 90.00,
                        Description = "Frankenstein, published anonymously in 1818, is Mary Shelley's original, uncensored vision, depicts a scientist creating a horrifying creature through unorthodox experiments. Inspired by conversations on galvanism and a dream, Shelley crafted this timeless horror story at the young age of 21.",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book3.jpg",
                        Title = "Dune",
                        Author = "Frank Herbert",
                        Price = 145.00,
                        Description = "Frank Herbert’s classic masterpiece—a triumph of the imagination and one of the bestselling science fiction novels of all time. Set on the desert planet Arrakis, Dune is the story of Paul Atreides—who would become known as Muad'Dib—and of a great family's ambition to bring to fruition mankind's most ancient and unattainable dream.",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book4.jpg",
                        Title = "A Clockwork Orange",
                        Author = "Anthony Burgess",
                        Price = 65.00,
                        Description = "In Anthony Burgess's influential nightmare vision of the future, criminals take over after dark. Teen gang leader Alex narrates in fantastically inventive slang that echoes the violent intensity of youth rebelling against society. Dazzling and transgressive, A Clockwork Orange is a frightening fable about good and evil and the meaning of human freedom. This edition includes the controversial last chapter not published in the first edition, and Burgess’s introduction, “A Clockwork Orange Resucked.”",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book5.jpg",
                        Title = "Pet Cematary",
                        Author = "Stephen King",
                        Price = 95.00,
                        Description = "Stephen King’s #1 New York Times bestseller Pet Sematary, a “wild, powerful, disturbing” (The Washington Post Book World) classic about evil that exists far beyond the grave—among King’s most iconic and beloved novels. When Dr. Louis Creed takes a new job and moves his family to the idyllic rural town of Ludlow, Maine, this new beginning seems too good to be true. Despite Ludlow’s tranquility, an undercurrent of danger exists here. Those trucks on the road outside the Creed’s beautiful old home travel by just a little too quickly, for one thing…as is evidenced by the makeshift graveyard in the nearby woods where generations of children have buried their beloved pets. Then there are the warnings to Louis both real and from the depths of his nightmares that he should not venture beyond the borders of this little graveyard where another burial ground lures with seductive promises and ungodly temptations. A blood-chilling truth is hidden there—one more terrifying than death itself, and hideously more powerful. As Louis is about to discover for himself sometimes, dead is better…",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book6.jpg",
                        Title = "Arabella",
                        Author = "Georgette Heyer",
                        Price = 80.00,
                        Description = "Arabella Tallant, a poor clergyman's daughter, sees an invitation from her London godmother as a ticket to a better life. Armed with beauty and virtue, she aims to secure a wealthy husband during her first London season. A chance encounter with the wealthy Robert Beaumaris leads to a misunderstanding, and Arabella pretends to be an heiress. Beaumaris plays along, thrusting her into high society and exposing her to various suitors. Despite becoming the talk of the ton, Arabella is drawn to Beaumaris. As their relationship develops, Beaumaris, a skilled dodger of matrimony, underestimates Arabella's true character, especially when she involves him in charitable acts.",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book7.jpg",
                        Title = "The Turn of the Screw",
                        Author = "Henry James",
                        Price = 60.00,
                        Description = "The Turn of the Screw, written by Henry James in 1898, is a horror novella that initially appeared serially in Collier's Weekly and later in the book \"The Two Magics.\" The story follows a young governess hired for her first job, overseeing two peculiar and silent children, Miles and Flora, at a eerie estate haunted by malevolent forces. The governess becomes increasingly horrified as she realizes these spectral entities are intent on corrupting the children. Despite her efforts, she discovers that Miles and Flora are strangely indifferent to the lurking evil, and the novella unfolds with a sense of suspense and psychological tension.",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/fiction/book8.jpg",
                        Title = "Norwegian Wood",
                        Author = "Haruki Murakami",
                        Price = 125.00,
                        Description = "Stunning and elegiac, Norwegian Wood first propelled Haruki Murakami into the forefront of the literary scene. Toru, a serious young college student in Tokyo, is devoted to Naoko, a beautiful and introspective young woman, but their mutual passion is marked by the tragic death of their best friend years before. As Naoko retreats further into her own world, Toru finds himself drawn to a fiercely independent and sexually liberated young woman. A magnificent coming-of-age story steeped in nostalgia, Norwegian Wood blends the music, the mood, and the ethos that were the sixties with a young man’s hopeless and heroic first love.",
                        BookCategory = BookCategory.Fiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book1.jpg",
                        Title = "The Six Wives of Henry VIII",
                        Author = "Antonia Frasier",
                        Price = 125.00,
                        Description = "In popular memory, the wives of Henry VIII are defined by their fate. But in Antonia Fraser’s pioneering study, the six queens emerge as rich and fascinating characters in their own right, not just the helpless victims of Henry’s obsession with a male heir. The story she tells us is by turns romantic and cruel, funny and sad, dramatic and enthralling. An international bestseller from the doyenne of historical biography, The Six Wives of Henry VIII is enriched with 32 pages of colour illustrations. There are the famous portraits by Hans Holbein, miniatures by Lucas Horenbout and views by Anton van den Wyngaerde, as well as letters, prayer books and palace scenes – many from the Royal Collection, the National Portrait Gallery and the British Library.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book2.jpg",
                        Title = "The Planets",
                        Author = "Andrew Cohen & Professor Brian Cox",
                        Price = 135.00,
                        Description = "The Planets is a fantastic voyage through the history of our solar system. Drawing on the latest discoveries from space telescopes and interplanetary probes, Andrew Cohen and Professor Brian Cox show how the story of our own world is intimately bound up with the fate of our celestial neighbours. The journey begins with the three inner planets: Sun-parched Mercury; Venus, once thought to be lush and fertile, now smothered in toxic gases; and Mars, too small to hold on to its own atmosphere. Cohen reveals the fearsome power of Jupiter – both a destroyer and a protector of worlds – and how Saturn may become the final place in our solar system where life can exist. Finally, the voyage reaches the mysterious ice giants of Uranus and Neptune, and the distant dwarf planet Pluto.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book3.jpg",
                        Title = "Micrographia",
                        Author = "Robert Hooke",
                        Price = 110.00,
                        Description = "It was two o’clock in the morning on 21 January 1665 when Samuel Pepys finally put down his bedtime reading and delivered his famous verdict on Robert Hooke’s work: ‘The most ingenious book that ever I read in my life’. Hooke's seminal work on microscopy, the study of objects through magnifying lenses and microscopes, presented previously unseen worlds to his readers. His fascinating observations and beautiful descriptions of what he saw had a far-reaching influence, making this one of the most important books in the history of science. The entire text of 1665 is accompanied by the breathtakingly detailed illustrations, including five stunning foldouts, that are the source of the book's enduring fame.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book4.jpg",
                        Title = "The Silk Roads",
                        Author = "Peter Frankopan",
                        Price = 225.00,
                        Description = "In this revelatory book, Peter Frankopan makes the case for a major re-evaluation of world history – one focused not on Europe but on central Asia, where East meets West. In The Silk Roads, the zone between the Mediterranean, Black Sea and Himalayas emerges as a birthplace of civilisations, empires and religions. From here, the ancient routes of the title – ‘the world’s central nervous system’ – spread not only trade, but scientific knowledge, slaves, disease and marauding armies. Frankopan shows how the Silk Roads brought about a profoundly interconnected world, where ripples created by events in Baghdad could be felt in Scandinavia.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book5.jpg",
                        Title = "The Order of Time",
                        Author = "Carlo Rovelli",
                        Price = 90.00,
                        Description = "Why can we alter the future but not the past, and is there any such thing as the present? We think of time as universal – moving forward, measured by clocks – but look more closely, and it reveals itself to be profoundly strange. In this thrilling dive into the nature of our universe, theoretical physicist Carlo Rovelli sweeps away all our easy assumptions. He shows that time flows faster or more slowly in different places, and vanishes altogether through the lens of quantum gravity theory. A number-one bestseller and one of Time’s ten best nonfiction books of the decade, The Order of Time is presented in a Folio edition unlike any other, thanks to award-winning designer Daniel Streat’s superb minimalist graphics.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book6.jpg",
                        Title = "The Right Stuff",
                        Author = "Tom Wolfe",
                        Price = 110.00,
                        Description = "‘What is it that makes a man willing to sit up on top of an enormous Roman candle, and wait for someone to light the fuse?’ In The Right Stuff, hailed as one of the greatest books ever written about space flight, Tom Wolfe sets out to answer the question, and lays bare the mindset and motivations of the first American astronauts to risk life and limb to beat the Soviets into orbit. He blows apart the mythology of the Mercury Seven – Deke Slayton, Gus Grissom, Alan Shepard, Wally Schirra, John Glenn, Scott Carpenter and Gordon Cooper – and the forerunner of them all, supersonic test pilot Chuck Yeager.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book7.jpg",
                        Title = "Byzantium",
                        Author = "Judith Herrin",
                        Price = 110.00,
                        Description = "The Byzantine Empire was a world power for more than 1,000 years, from the founding of its magnificent capital, Constantinople (modern Istanbul) by Constantine the Great in 330 to its fall to the Ottoman Turks in 1453. In this sweeping history, Judith Herrin examines the life and legacy of this great civilisation that evolved out of the Roman Empire – its emperors and empresses, conquests and Crusades, desperate sieges, and importance as a bulwark between the West and the burgeoning Islamic world, making possible the ascent of modern Europe. Byzantium’s cultural glories are displayed in 32 pages of dazzling colour images, including great churches and monasteries, gold and silver work, painted and ivory icons, and vivid mosaics.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/non-fiction/book8.jpg",
                        Title = "Pole to Pole",
                        Author = "Michael Palin",
                        Price = 70.00,
                        Description = "Pole to Pole is Michael Palin’s legendary account account of an extraordinary journey from the North to the South Pole. His challenge was to follow the 30°E longitude line by land and sea, taking to the air only as a last resort. In the gruelling six-month trek, Palin covered 23,000 miles across 17 countries, including Norway, Russia and Ukraine (at the time, both part of the USSR), Turkey, Egypt, Ethiopia, Zimbabwe and Chile. Opening with a new introduction by the author, in which he recalls his childhood dreams of far-off lands and legendary adventurers, this lavish Folio edition includes 24 pages of colour photography – a rich compendium of landscapes, nations and people, bookended by shots of Palin standing alone at each extremity of the earth.",
                        BookCategory = BookCategory.NonFiction
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book1.jpg",
                        Title = "Plants of the Americas",
                        Author = "Nikolaus von Jacquin",
                        Price = 1050.00,
                        Description = "The enduring appeal of Plants of the Americas unquestionably lies in the 264 exquisitely beautiful and scientifically accurate plant portraits, as well as the exuberant title pages, produced by the Bauer brothers and their team. This facsimile of the copy of Plants of the Americas held at the Royal Botanic Gardens, Kew – the first ever facsimile of any copy of this rare publication – reproduces the hand-painted originals with stunning fidelity. The plates constitute a powerful artistic and intellectual legacy, while the accompanying commentary provides an understanding of the significance of Jacquin’s text which was printed in a separate volume and has never been translated from the original Latin.",
                        BookCategory = BookCategory.LimitedEdition
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book2.jpg",
                        Title = "Casino Royale",
                        Author = "Ian Fleming",
                        Price = 725.00,
                        Description = "Casino Royale was first published exactly 70 years ago, on 13 April 1953. To celebrate this important anniversary, the Folio Society is releasing the ultimate collector’s edition – bound in blocked leather and limited to just 750 copies, each numbered by hand and signed by the artist Fay Dalton. Award-winning novelist Kim Sherwood, chosen by Ian Fleming Publications to expand the world of James Bond with three new novels, has contributed a fascinating introduction exclusive to this Folio limited edition.",
                        BookCategory = BookCategory.LimitedEdition
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book3.jpg",
                        Title = "Roadside Picnic",
                        Author = "Arkady & boris Strugatsky",
                        Price = 395.00,
                        Description = "Years after the aliens have been and gone, six landing sites, or Zones, around the world still contain the mysterious remnants of the visitation. Toxic wastelands of unimaginable terror, they hold dangerous artefacts and silvery threads of death that compel the straight-talking stalker, Redrick Shuhart, to keep coming back, his life dominated by the black-market trade in alien products. First published in 1972 from behind the Iron Curtain, the Strugatsky Brothers’ Roadside Picnic became a globally revered sci-fi classic and inspired the Andrei Tarkovsky film Stalker.",
                        BookCategory = BookCategory.LimitedEdition
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book4.jpg",
                        Title = "The Tale of Peter Rabbit",
                        Author = "Beatrix Potter",
                        Price = 495.00,
                        Description = "To mark the 120th anniversary of a story that has delighted countless children, the Folio Society is excited to publish exclusive editions of Beatrix Potter’s inimitable classic, The Tale of Peter Rabbit. Collectors can follow the emergence of the miniature masterpiece from the seeds of the story in a now famous picture letter written to entertain a sick child, through Beatrix Potter’s privately printed edition with its distinctive line drawings, to the mock-up book – or maquette – handwritten in Potter’s beautiful script showing exactly how she wished the words and pictures to appear.",
                        BookCategory = BookCategory.LimitedEdition
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book5.jpg",
                        Title = "Rob Roy",
                        Author = "Sir Walter Scott",
                        Price = 475.00,
                        Description = "Published to mark the 250th anniversary of Scott's birth, this stunning volume brings together his definitive text, an exclusive new foreword by celebrated historical novelist Diana Gabaldon, and arresting illustrations by renowned Scottish artist June Carey. Leather-bound, hand-numbered and signed by both introducer and illustrator, this is the ultimate commemorative edition of the classic historical novel.",
                        BookCategory = BookCategory.LimitedEdition
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book6.jpg",
                        Title = "Edward Thomas: Selected Poems",
                        Author = "Edward Thomas",
                        Price = 355.00,
                        Description = "A selection of Edward Thomas’s poems presented in a limited edition to mark the centenary of his death. This book has been designed to reflect the values of the fine press movement of the early 20th century. Edward Thomas only began writing poetry two years before he was killed in action at Arras in 1917. Long regarded as a ‘poet’s poet’, he is now acknowledged as one of the greatest writers of the English countryside, his verse grounded in a pastoral patriotism that makes him unique among the poets of the First World War.",
                        BookCategory = BookCategory.LimitedEdition
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book7.jpg",
                        Title = "Wilfred Owen: Selected Poems",
                        Author = "Wilfred Owen",
                        Price = 355.00,
                        Description = "Wilfred Owen is the ultimate soldier-poet, a writer whose verses have irrevocably shaped our understanding of the horrors of the First World War. For this new limited edition, Owen Sheers has written a specially commissioned introduction and Neil Bousfield has created engravings and vignettes to accompany the poetry. The design honours the craft techniques employed at the beginning of the 20th century, with letterpress printing on mould-made paper, a goatskin leather quarter-binding and hand-made paste-paper sides by Victoria Hall.",
                        BookCategory = BookCategory.LimitedEdition
                    },
                    new Book
                    {
                        ImgLink = "~/photos/limited-editions/book8.jpg",
                        Title = "London",
                        Author = "Alvin Landon Coburn",
                        Price = 320.00,
                        Description = "One of the greatest metropolises of the early 20th century, each captured in 20 photogravures by the pictorialist genius Alvin Langdon Coburn. These facsimiles of a volume of luminous and evocative images, first published in 1909 and 1910 respectively, convey the urban beauty of London in the age of steam. The original introduction and foreword, by Hilaire Belloc for London, are included. The facsimiles are accompanied by a separate leaflet featuring a specially commissioned introduction by Geoff Dyer and a new essay by Rut Blees Luxemburg.",
                        BookCategory = BookCategory.LimitedEdition
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
