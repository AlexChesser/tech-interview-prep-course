namespace _278_FirstBadVersion
{
    /* The isBadVersion API is defined in the parent class VersionControl.
          bool IsBadVersion(int version); */

    public class Solution : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            int highest = n;
            int lowest = 0;
            while (lowest < highest)
            {
                int checkAt = lowest + (highest - lowest) / 2;
                if (IsBadVersion(checkAt))
                {
                    highest = checkAt;
                }
                else
                {
                    lowest = checkAt + 1;
                }

            }
            return lowest;
        }
    }

    public class VersionControl
    {
        public int BadVersion;
        protected bool IsBadVersion(int version)
        {
            return version >= BadVersion;
        }
    }
}