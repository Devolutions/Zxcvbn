using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Devolutions.Zxcvbn.Tests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void chicken123()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("chicken123");

            Assert.AreEqual("chicken123", result.Password);
            Assert.AreEqual(4.31175d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("9 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("34 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void poulet123()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("poulet123");

            Assert.AreEqual("poulet123", result.Password);
            Assert.AreEqual(6.29916d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("2 years", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 days", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 minutes", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void zxcvbn()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("zxcvbn");

            Assert.AreEqual("zxcvbn", result.Password);
            Assert.AreEqual(1.763428d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("35 minutes", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("6 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a top-100 common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void qwER43()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("qwER43@!");

            Assert.AreEqual("qwER43@!", result.Password);
            Assert.AreEqual(7.9565077d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Short keyboard patterns are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void Tr0ub4dour3()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("Tr0ub4dour&3");

            Assert.AreEqual("Tr0ub4dour&3", result.Password);
            Assert.AreEqual(7.2800775d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("21 years", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("22 days", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("32 minutes", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(3, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void correcthorsebatterystaple()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("correcthorsebatterystaple");

            Assert.AreEqual("correcthorsebatterystaple", result.Password);
            Assert.AreEqual(14.436958d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("8 hours", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void coRrecth0rsebaery9232007staple()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("coRrecth0rseba++ery9.23.2007staple$");

            Assert.AreEqual("coRrecth0rseba++ery9.23.2007staple$", result.Password);
            Assert.AreEqual(20.711855d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void pssword()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("p@ssword");

            Assert.AreEqual("p@ssword", result.Password);
            Assert.AreEqual(0.69897d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("3 minutes", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void pword()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("p@$$word");

            Assert.AreEqual("p@$$word", result.Password);
            Assert.AreEqual(0.9542425d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("5 minutes", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void _123456()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("123456");

            Assert.AreEqual("123456", result.Password);
            Assert.AreEqual(0.30103d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("1 minute", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a top-10 common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void _123456789()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("123456789");

            Assert.AreEqual("123456789", result.Password);
            Assert.AreEqual(0.7781513d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("4 minutes", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a top-10 common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void _11111111()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("11111111");

            Assert.AreEqual("11111111", result.Password);
            Assert.AreEqual(1.80618d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("38 minutes", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("6 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a top-100 common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void zxcvbnm()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("zxcvbnm,./");

            Assert.AreEqual("zxcvbnm,./", result.Password);
            Assert.AreEqual(3.589838d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("2 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("6 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Straight rows of keys are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void love88()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("love88");

            Assert.AreEqual("love88", result.Password);
            Assert.AreEqual(4.220108d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("7 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("28 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void angel08()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("angel08");

            Assert.AreEqual("angel08", result.Password);
            Assert.AreEqual(4.3580112d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("10 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("38 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Common names and surnames are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void monkey13()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("monkey13");

            Assert.AreEqual("monkey13", result.Password);
            Assert.AreEqual(4.11096d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("5 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("22 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("1 second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void iloveyou()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("iloveyou");

            Assert.AreEqual("iloveyou", result.Password);
            Assert.AreEqual(1.6812413d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("29 minutes", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("5 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a top-100 common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void woaini()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("woaini");

            Assert.AreEqual("woaini", result.Password);
            Assert.AreEqual(4.062319d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("5 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("19 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("1 second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void wang()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("wang");

            Assert.AreEqual("wang", result.Password);
            Assert.AreEqual(2.9459608d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("9 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("1 minute", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Names and surnames by themselves are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void tianya()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("tianya");

            Assert.AreEqual("tianya", result.Password);
            Assert.AreEqual(5.31492d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("3 months", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("6 hours", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("21 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Common names and surnames are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void zhang198822()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("zhang198822");

            Assert.AreEqual("zhang198822", result.Password);
            Assert.AreEqual(7.873274d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("84 years", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Dates are often easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void li4478()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("li4478");

            Assert.AreEqual("li4478", result.Password);
            Assert.AreEqual(6.0000005d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("1 year", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("1 day", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 minutes", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void a6a4Aa8a()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("a6a4Aa8a");

            Assert.AreEqual("a6a4Aa8a", result.Password);
            Assert.AreEqual(8d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void b6b4Bb8b()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("b6b4Bb8b");

            Assert.AreEqual("b6b4Bb8b", result.Password);
            Assert.AreEqual(8d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void z6z4Zz8z()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("z6z4Zz8z");

            Assert.AreEqual("z6z4Zz8z", result.Password);
            Assert.AreEqual(8d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void aiIiAaIA()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("aiIiAaIA");

            Assert.AreEqual("aiIiAaIA", result.Password);
            Assert.AreEqual(8d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void zxXxZzXZ()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("zxXxZzXZ");

            Assert.AreEqual("zxXxZzXZ", result.Password);
            Assert.AreEqual(8d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void passward()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("pässwörd");

            Assert.AreEqual("pässwörd", result.Password);
            Assert.AreEqual(8d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void alphabravocharliedelta()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("alpha bravo charlie delta");

            Assert.AreEqual("alpha bravo charlie delta", result.Password);
            Assert.AreEqual(17.7335d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("2 years", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void abcdefghijklmnopqrstuvwxyz0123456789()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("a b c d e f g h i j k l m n o p q r s t u v w x y z 0 1 2 3 4 5 6 7 8 9");

            Assert.AreEqual("a b c d e f g h i j k l m n o p q r s t u v w x y z 0 1 2 3 4 5 6 7 8 9", result.Password);
            Assert.AreEqual(71d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void abc123()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("a b c 1 2 3");

            Assert.AreEqual("a b c 1 2 3", result.Password);
            Assert.AreEqual(11d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("10 seconds", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void correcthorsebatterystaple2()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("correct-horse-battery-staple");

            Assert.AreEqual("correct-horse-battery-staple", result.Password);
            Assert.AreEqual(20.330032d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void correcthorsebatterystaple3()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("correct.horse.battery.staple");

            Assert.AreEqual("correct.horse.battery.staple", result.Password);
            Assert.AreEqual(20.330032d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void correcthorsebatterystaple4()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("correct,horse,battery,staple");

            Assert.AreEqual("correct,horse,battery,staple", result.Password);
            Assert.AreEqual(20.330032d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void correcthorsebatterystaple5()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("correct~horse~battery~staple");

            Assert.AreEqual("correct~horse~battery~staple", result.Password);
            Assert.AreEqual(20.330032d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void WhyfaultthebardifhesingstheArgivesharshfate()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("WhyfaultthebardifhesingstheArgives�harshfate?");

            Assert.AreEqual("WhyfaultthebardifhesingstheArgives�harshfate?", result.Password);
            Assert.AreEqual(40.754463d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void EupithessonAntinousbroketheirsilence()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("Eupithes�sonAntinousbroketheirsilence");

            Assert.AreEqual("Eupithes�sonAntinousbroketheirsilence", result.Password);
            Assert.AreEqual(29.048d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void Athenalavishedamarveloussplendor()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("Athena lavished a marvelous splendor");

            Assert.AreEqual("Athena lavished a marvelous splendor", result.Password);
            Assert.AreEqual(24.184618d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void buckmulliganstenderchant()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("buckmulliganstenderchant");

            Assert.AreEqual("buckmulliganstenderchant", result.Password);
            Assert.AreEqual(16.69761d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("2 months", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void seethenthatyewalkcircumspectly()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("seethenthatyewalkcircumspectly");

            Assert.AreEqual("seethenthatyewalkcircumspectly", result.Password);
            Assert.AreEqual(25.570543d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void LihiandthepeopleofMorianton()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("LihiandthepeopleofMorianton");

            Assert.AreEqual("LihiandthepeopleofMorianton", result.Password);
            Assert.AreEqual(21.446474d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void establishedinthecityofZarahemla()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("establishedinthecityofZarahemla");

            Assert.AreEqual("establishedinthecityofZarahemla", result.Password);
            Assert.AreEqual(21.517439d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void _()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("!\"�$%^&*()");

            Assert.AreEqual("!\"�$%^&*()", result.Password);
            Assert.AreEqual(7.0161138d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("12 years", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("12 days", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("17 minutes", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Straight rows of keys are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void D0g()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("D0g..................");

            Assert.AreEqual("D0g..................", result.Password);
            Assert.AreEqual(5.6454225d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("6 months", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("12 hours", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("44 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Repeats like \"aaa\" are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void abcdefghijk987654321()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("abcdefghijk987654321");

            Assert.AreEqual("abcdefghijk987654321", result.Password);
            Assert.AreEqual(4.176091d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("6 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("25 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Sequences like abc or 6543 are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void neverforget1331997()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("neverforget13/3/1997");

            Assert.AreEqual("neverforget13/3/1997", result.Password);
            Assert.AreEqual(9.593628d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(3, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("12 years", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("5 days", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void _1qaz2wsx3edc()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("1qaz2wsx3edc");

            Assert.AreEqual("1qaz2wsx3edc", result.Password);
            Assert.AreEqual(3.0004342d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("10 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void temppass22()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("temppass22");

            Assert.AreEqual("temppass22", result.Password);
            Assert.AreEqual(5.5882716d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("5 months", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("11 hours", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("39 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void briansmith()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("briansmith");

            Assert.AreEqual("briansmith", result.Password);
            Assert.AreEqual(4.176091d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("6 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("25 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Common names and surnames are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void briansmith4mayor()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("briansmith4mayor");

            Assert.AreEqual("briansmith4mayor", result.Password);
            Assert.AreEqual(10.178977d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("47 years", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("17 days", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("2 seconds", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void password1()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("password1");

            Assert.AreEqual("password1", result.Password);
            Assert.AreEqual(2.2787535d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("2 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("19 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void viking()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("viking");

            Assert.AreEqual("viking", result.Password);
            Assert.AreEqual(2.38739d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("2 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("24 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void thx1138()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("thx1138");

            Assert.AreEqual("thx1138", result.Password);
            Assert.AreEqual(2.3201463d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("2 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("21 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void ScoRpi0ns()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("ScoRpi0ns");

            Assert.AreEqual("ScoRpi0ns", result.Password);
            Assert.AreEqual(5.4618945d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("4 months", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("8 hours", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("29 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void doyouknow()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("do you know");

            Assert.AreEqual("do you know", result.Password);
            Assert.AreEqual(9.000005d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(3, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 years", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("1 day", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void ryanhunter2000()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("ryanhunter2000");

            Assert.AreEqual("ryanhunter2000", result.Password);
            Assert.AreEqual(8.003245d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(3, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void rianhunter2000()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("rianhunter2000");

            Assert.AreEqual("rianhunter2000", result.Password);
            Assert.AreEqual(8.39794d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(3, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("9 months", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("7 hours", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void asdfghju7654rewq()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("asdfghju7654rewq");

            Assert.AreEqual("asdfghju7654rewq", result.Password);
            Assert.AreEqual(8.965291d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(3, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 years", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("1 day", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void AOEUIDHGLS_()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("AOEUIDHG&*()LS_");

            Assert.AreEqual("AOEUIDHG&*()LS_", result.Password);
            Assert.AreEqual(9.107258d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(3, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("4 years", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("1 day", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void _12345678()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("12345678");

            Assert.AreEqual("12345678", result.Password);
            Assert.AreEqual(0.60206d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("2 minutes", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a top-10 common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void defghi6789()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("defghi6789");

            Assert.AreEqual("defghi6789", result.Password);
            Assert.AreEqual(4.40824d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("11 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("43 minutes", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("Sequences like abc or 6543 are easy to guess", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void rosebud()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("rosebud");

            Assert.AreEqual("rosebud", result.Password);
            Assert.AreEqual(2.434569d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("3 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("27 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void Rosebud()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("Rosebud");

            Assert.AreEqual("Rosebud", result.Password);
            Assert.AreEqual(2.7347999d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("5 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("54 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void ROSEBUD()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("ROSEBUD");

            Assert.AreEqual("ROSEBUD", result.Password);
            Assert.AreEqual(2.7347999d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("5 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("54 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void rosebuD()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("rosebuD");

            Assert.AreEqual("rosebuD", result.Password);
            Assert.AreEqual(2.7347999d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(0, result.Score);

            Assert.AreEqual("5 hours", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("54 seconds", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("less than a second", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is a very common password", result.Feedback.Warning);
            Assert.AreEqual(1, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void ros3bud99()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("ros3bud99");

            Assert.AreEqual("ros3bud99", result.Password);
            Assert.AreEqual(4.807535d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("27 days", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 hours", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("6 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void r0s3bud99()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("r0s3bud99");

            Assert.AreEqual("r0s3bud99", result.Password);
            Assert.AreEqual(5.073352d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(1, result.Score);

            Assert.AreEqual("2 months", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("3 hours", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("12 seconds", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("This is similar to a commonly used password", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void R038uD99()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("R0$38uD99");

            Assert.AreEqual("R0$38uD99", result.Password);
            Assert.AreEqual(6.1175365d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(2, result.Score);

            Assert.AreEqual("1 year", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 days", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("2 minutes", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("less than a second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(2, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void verlineVANDERMARK()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("verlineVANDERMARK");

            Assert.AreEqual("verlineVANDERMARK", result.Password);
            Assert.AreEqual(10.389181d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("76 years", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("28 days", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("2 seconds", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void eheuczkqyq()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("eheuczkqyq");

            Assert.AreEqual("eheuczkqyq", result.Password);
            Assert.AreEqual(10d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(3, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("31 years", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("12 days", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("1 second", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void rWibMFACxAUGZmxhVncy()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("rWibMFACxAUGZmxhVncy");

            Assert.AreEqual("rWibMFACxAUGZmxhVncy", result.Password);
            Assert.AreEqual(20d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }

        [TestMethod]
        public void Ba9ZyWABu99BK6MBgbH88Tofvvsw()
        {
            ZxcvbnResult result = Zxcvbn.Evaluate("Ba9ZyWABu99[BK#6MBgbH88Tofv)vs$w");

            Assert.AreEqual("Ba9ZyWABu99[BK#6MBgbH88Tofv)vs$w", result.Password);
            Assert.AreEqual(32d, result.GuessesLog10, 0.01d);
            Assert.AreEqual(4, result.Score);

            Assert.AreEqual("centuries", result.ThrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.UnthrottledOnlineAttackCrackTime);
            Assert.AreEqual("centuries", result.OfflineSlowHashManyCoresCrackTime);
            Assert.AreEqual("centuries", result.OfflineFastHashManyCoresCrackTime);

            Assert.AreEqual("", result.Feedback.Warning);
            Assert.AreEqual(0, result.Feedback.Suggestions.Length);
        }




    }
}
