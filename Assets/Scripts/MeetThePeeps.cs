using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetThePeeps : MonoBehaviour
{
    public Text NameText, StatText, EquipText, DialogueText;
    public Image faceImage;


    public string TalktoAdventurers(PCharacter speaker)
    {
        string output = "";
        if (speaker.pcMotivation == "Money")
        {
            if (speaker.motIndex == 1) output = "I need money. You need help. Let’s go.";
            if (speaker.motIndex == 2) output = "Why would I want to plunge into the Deadly Dark Deeps with you? It’s simple, really. They are down there with literal tons of gold and treasure, just sitting there. I want some of that for myself.";
            if (speaker.motIndex == 3) output = "When the Ghalidans broke through the walls at Hushalla, my family was forced to flee with nothing but the clothes we wore. Now, I will fight to earn what I need to improve our standing, to recover our place in the world!";
            if (speaker.motIndex == 4) output = "Do you know what makes the world go around? Money. It all comes down to money. I doubt I will ever have enough!";
            if (speaker.motIndex == 5) output = "My family never had much but they raised me as best they could. I was happy enough on my farm, but now that’s gone, and I gotta make a living somehow.";
            if (speaker.motIndex == 6) output = "It’s pretty simple really. First, I get the money and then I get the power. The more money, the more power. I am going to be a King!";
            if (speaker.motIndex == 7) output = "I find that I need more money than I am able to easily procure. Once we have delved a bit, I plan to take what I have earned and use it to ease the burdens of the war-orphans in the south.";
        }
        if (speaker.pcMotivation == "Power")
        {
            if (speaker.motIndex == 1) output = "I sense great power below us, calling me.";
            if (speaker.motIndex == 2) output = "You hear such wondrous tales, you know? I heard about this one guy, he found a knife in a dungeon a lot like this. Used it for eating, cutting rope, you know, just the usual stuff. Only, this knife could talk! It had all these spells on it, and he used it to cut rope! Can you imagine!";
            if (speaker.motIndex == 3) output = "Khalidan. Montegrai. Solemenai. Just three examples, but it seems all the great Sorcerers got their start in places like these. I may be humble now, but my Power will grow!";
            if (speaker.motIndex == 4) output = "Gotta keep going, you know? Gotta keep delving deeper, finding my paydays. Gotta keep training. It is the only way to get more powerful. Gotta keep getting more powerful, you know?";
            if (speaker.motIndex == 5) output = "I will tell you simply: I seek power. Not for myself, but for my children. I have tried to leave a legacy for my family, but for naught. But here? In this place? I will find the power I need to ensure a legacy for my children.";
            if (speaker.motIndex == 6) output = "I may not be much right now, but that will change! You are going to hire me, and we are going to go and find what we need to be the most powerful adventurers ever!";
            if (speaker.motIndex == 7) output = "Nobility means nothing without power. Nobility directs our intentions, but power fuels the ambitions into reality. I have my nobility and a purpose, but together perhaps we can find the power I need?";
        }
        if (speaker.pcMotivation == "Honor")
        {
            if (speaker.motIndex == 1) output = "I must delve. It is a matter of Honor.";
            if (speaker.motIndex == 2) output = "Honor drives me, Honor comforts me. When nothing is left; no friends, no family, no lovers… I have my Honor still. My Honor has led me here, and my Honor leads me below, and so I will go.";
            if (speaker.motIndex == 3) output = "Ser Gregori was my master, but he set me free when he rode south to war. I served him as best I could, but in the end I was not chosen to be his squire. However, here in the Deadly Dark Deeps, I will find Honor enough to earn my place in the Light Corps!";
            if (speaker.motIndex == 4) output = "Some of these ‘Adventurers’ are little more than bandits. They talk about money, or the tales people will sing about them, or taking pleasure in death. Bandits. It is simple: We must stand against darkness. Honor demands it.";
            if (speaker.motIndex == 5) output = "You want to know why I am here? I didn’t hear about this place and travel across the world to get here, I was born right over there. When the Deeps opened, I had a puppy named Bill. Those first days, we didn’t know what was happening, you know? There were no guards. Things were wandering town willy-nilly… and one of those bastards got my puppy. My little Bill. Now, on my Honor, I will kill every last one of them…";
            if (speaker.motIndex == 6) output = "Good day! Or good Evening! Honorable greetings! Are you here to explore the Deadly Dark Deeps too? Let’s go together!";
            if (speaker.motIndex == 7) output = "Nobility means nothing without Honor. Nobility directs our intentions, but Honor gives us something to uphold, something greater than us to work toward and judge our actions against. Honor is the backdrop that lets us be Noble. I am here to fight the darkness, because it is my Honor to do so.";
        }
        if (speaker.pcMotivation == "Glory")
        {
            if (speaker.motIndex == 1) output = "Nobody knows who I am, but someday they will.";
            if (speaker.motIndex == 2) output = "Ha! I will give the Bards something to sing about! My name will be on every tongue! In every song! Young’uns will hear the stories and dream about their own adventures to come, just as I did as a lad! No matter how I end, I will leave a tale to be told!";
            if (speaker.motIndex == 3) output = "In the story of Samosite, he slew a hundred foes with little more than a club fashioned from the jawbone of a wyvern. Imagine what my story will be! In this dungeon, I will find my hundred foes, and our battle will be Glorious!";
            if (speaker.motIndex == 4) output = "Nobody has ever heard of me, not yet. But that will change! These are the Glory days!";
            if (speaker.motIndex == 5) output = "You want to know what a tragedy is? Nobody sings about me! My name is perfect for stories, it just rolls off the tongue!";
            if (speaker.motIndex == 6) output = "Nobody has ever heard of me, not yet. But that will change! These are the Glory days!";
            if (speaker.motIndex == 7) output = "Glory is coming for me, and when everyone knows my name, I will marshal an army and retake my family’s birthright!";
        }
        if (speaker.pcMotivation == "Fate")
        {
            if (speaker.motIndex == 1) output = "I have come to meet my Fate.";
            if (speaker.motIndex == 2) output = "Some people are Fated to meet, and I think we are two such. Everyone has a destiny, you know? All you need do is watch to see that it all works out.";
            if (speaker.motIndex == 3) output = "Everyone is talking about the Dark Deadly Deeps, but this is not the only time this has opened. This small sliver is just a fraction of the Deeps. The true Dark Deadly Deeps is far older and far more vast than people dream. It is my Destiny to seek out more, to delve deeper than ever before.";
            if (speaker.motIndex == 4) output = "I will die down there. It is ok, I am ready. I have prepared. My affairs are in order. Let’s go meet my Fate.";
            if (speaker.motIndex == 5) output = "I will die down there. It is ok, I am ready. I have prepared. My affairs are in order. Let’s go meet my Fate.";
            if (speaker.motIndex == 6) output = "Ever since I was little, I have known that I have a destiny. A Fate. I am marked for great things!";
            if (speaker.motIndex == 7) output = "Fate looms over us all. Everyone has a destiny. Perhaps mine is here. Perhaps it is further on in time. It hardly matters, I will meet my Fate when it is time to do so.";
        }
        if (speaker.pcMotivation == "Duty")
        {
            if (speaker.motIndex == 1) output = "It is my Duty to delve the Deadly Dark Deeps.";
            if (speaker.motIndex == 2) output = "I suppose I am here because of my father. He was an adventurer, and he wanted me to follow in his footsteps. I hesitated when I heard of the war in the south, all the adventurers went as soon as it started, but I stayed behind. That is why when I heard about the Deadly Dark Deeps opening here, I knew I had to come. This is my chance to fulfill my Father’s wishes.";
            if (speaker.motIndex == 3) output = "I was a guard in Hamilton, on the road south of here. My brother lives in Thelmore, but he disappeared when the Deadly Dark Deeps opened. I am here to find out what happened to him, it is my duty to my family.";
            if (speaker.motIndex == 4) output = "I was a guard in Hamilton, on the road south of here. My brother lives in Thelmore, but he disappeared when the Deadly Dark Deeps opened. I am here to find out what happened to him, it is my duty to my family.";
            if (speaker.motIndex == 5) output = "I was a guard in Hamilton, on the road south of here. My brother lives in Thelmore, but he disappeared when the Deadly Dark Deeps opened. I am here to find out what happened to him, it is my duty to my family.";
            if (speaker.motIndex == 6) output = "I think we all have a Duty to stand against the darkness. Who knows what is down there? We are all that is holding it back so these good people can live their lives.";
            if (speaker.motIndex == 7) output = "Nobility means nothing without Duty. Knights talk about Honor and Glory, but Duty is what sticks when everything else has run out. Without Duty, what purpose has Nobility?";
        }
        if (speaker.pcMotivation == "Curiosity")
        {
            if (speaker.motIndex == 1) output = "Why do I want to go into the Deadly Dark Deeps? Because it is there.";
            if (speaker.motIndex == 2) output = "Can you imagine? A whole complex below a sleepy little town like this! How long has it been there? Where did it come from? Why was it built? Why here? How could no-one have stumbled upon it before? I mean, these questions keep me up at night! I have to know!";
            if (speaker.motIndex == 3) output = "This is not the whole of the Deadly Dark Deeps of course. The Deadly Dark Deeps are vast, containing whole civilizations. Entrances have been found on the Eastern continent! This entrance is curiously stable, however, and it will be rewarding to see how deep it goes.";
            if (speaker.motIndex == 4) output = "My mother always told me that my nose would get me in trouble if I kept sticking it in other people’s business. She is probably right, but still, it seems like a dungeon opening under town is everyone’s business, right?";
            if (speaker.motIndex == 5) output = "My uncle lived in Thelmore, but he disappeared a short time after the Deadly Dark Deeps opened. He kept a journal, and in it he describes having strange dreams for months before the opening. They puzzled and disturbed him, but it seems clear now that he was dreaming about something in the Deeps… but what? I must know!";
            if (speaker.motIndex == 6) output = "Does it seem odd to you? A whole dungeon locked off from the world until it was breached by some poor guy who wanted to dig a well in the wrong place? I mean, what lived there before? How could they live in the darkness, with no sunlight or plants? Just one question I want to find an answer to!";
            if (speaker.motIndex == 7) output = "I do not simply wish to improve my standing or self, I have no malice in my heart for the things below. No! Rather, I am curious about them! I am eager to catalog any new creatures from below! What are their habits? What is their diet? Do they live in communities as we do? Do they have skills we can learn? I have so many questions!";
        }
        if (speaker.pcMotivation == "Bloodlust")
        {
            if (speaker.motIndex == 1) output = "–grunt-";
            if (speaker.motIndex == 2) output = "Look buddy, it is really, really simple. I am here to kill things. That’s it. The more things I kill, the happier I am.";
            if (speaker.motIndex == 3) output = "Black Razor, Blade of the Lune, Cadmus… These are only some of the most powerful weapons of all time, all pulled from forgotten dungeons like this one. I will find a weapon of legend here, and I will use it to write my legend in the blood of my enemies!";
            if (speaker.motIndex == 4) output = "Look, friend… I have this problem. Blood is all I think about, it is in my dreams, it is in my heart. I just need to kill, all the time. Here, I can finally let loose! I can kill them all! MUW-HA-HA-HAAA!";
            if (speaker.motIndex == 5) output = "Did you hear about that guy’s dog? GRRRR! I WILL KILL THEM ALL! THEY WILL ALL DIE! GRRRR!";
            if (speaker.motIndex == 6) output = "Just keep killing, just keep killing, La la la la la la la!  Everything will be okay!";
            if (speaker.motIndex == 7) output = "Nobility means nothing without strength. What good is noble spirit if you do not kill everything that stands against you? What good is duty, if you do not remove anything that could keep you to it? What good is honor if you do not wash every stain from it with the blood of your enemies? No, it is clear… being Noble means making other people die.";
        }
        output = "I belong to SaveGame # " + speaker.SaveGameID;
        return output;
    }
}
