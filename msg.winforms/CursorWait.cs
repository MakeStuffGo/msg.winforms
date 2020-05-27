using System;
using System.Windows.Forms;

namespace msg.winforms
{
    public static class MsgCursor
    {
        /// <summary>
        /// Creates a disposible object that will set the given cursor on initialization and reset to default when disposed.
        /// </summary>
        public static IDisposable ShowUntilDisposed(this Cursor cursor)
        {
            return new CursorWait(cursor);
        }

        /// <summary>
        /// Sets the given cursor as default while the given action is performed.
        /// </summary>
        public static void ShowWhile(this Cursor cursor, Action action)
        {
            using (cursor.ShowUntilDisposed())
                action();
        }

        /// <summary>
        /// Sets the given cursor as default while the given action is performed.
        /// </summary>
        public static T ShowWhile<T>(this Cursor cursor, Func<T> action)
        {
            using (cursor.ShowUntilDisposed())
                return action();
        }
    }

    internal class CursorWait : IDisposable
    {     
        public CursorWait(Cursor cursor)
        {
            Cursor.Current = cursor;
        }

        public void Dispose()
        {
            Cursor.Current = Cursors.Default;
            Application.UseWaitCursor = false;
        }
    }
}
