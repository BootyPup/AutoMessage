using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;

namespace fr34kyn01535.MessageAnnouncer
{
    public sealed class TextCommand
    {
        public string Name;
        public string Help;
        [XmlArrayItem("Line")]
        public List<string> Text;
    }

    public sealed class Message
    {
        [XmlAttribute("Text")]
        public string Text;

        [XmlAttribute("Color")]
        public string Color;

        public Message(string text, string color)
        {
            Text = text;
            Color = color;
        }
        public Message()
        {
            Text = "";
            Color = "";
        }
    }

    public class MessageAnnouncerConfiguration : IRocketPluginConfiguration
    {
        public int Interval;

        [XmlArrayItem("Message")]
        [XmlArray(ElementName = "Messages")]
        public Message[] Messages;

        [XmlArrayItem("TextCommand")]
        [XmlArray(ElementName = "TextCommands")]
        public List<TextCommand> TextCommands;

        public void LoadDefaults()
        {
            Interval = 180;
            Messages = new Message[]{
                new Message("Welcome to Fluffy's Zombie House, we hope you enjoy your stay!"),
                new Message("Join our TeamSpeak 3 server at 66.55.149.29:9197"),
                new Message("If you have any questions ask an admin on our TeamSpeak 3 server!"),
                new Message("Please chat in english. Be polite."),
            };
            TextCommands = new List<TextCommand>(){
                new TextCommand(){Name="rules",Help="Shows the server rules",Text = new List<string>(){
                    "#1 No bug using, exploiting or abuse of powers",
                    "#2 Don't ask admins for items, loot respawn, ect.",
                    "#3 Please speak english in the public chat"}
                }
            };
        }
    }
}
