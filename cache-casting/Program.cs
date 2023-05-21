public class Cache { }
public class DiskCache : Cache { }
public class MemoryCache : Cache { }
public class OptimizedDiskCache : DiskCache { }

class Program
{
    // Checking for runtime errors
    public static void Main(string[] args)
    {
        // Case 1 [Passed]
        // OptimizedDiskCache optimizedDiskCache = new OptimizedDiskCache();
        // Cache cache = (Cache)optimizedDiskCache;
        // Case 2 [Runtime Exception]
        // MemoryCache memoryCache = new MemoryCache();
        // Cache cache = (Cache)memoryCache;
        // DiskCache diskCache = (DiskCache)cache;
        // Case 3 [Runtime Exception]
        // DiskCache diskCache = new DiskCache();
        // OptimizedDiskCache optimizedDiskCache = (OptimizedDiskCache)diskCache;
        // Case 4 [Passed]
        // OptimizedDiskCache optimizedDiskCache = new OptimizedDiskCache();
        // DiskCache diskCache = (DiskCache)optimizedDiskCache;
        // Case 5 [Runtime Exception]
        // Cache cache = new Cache();
        // MemoryCache memoryCache = (MemoryCache)cache;
        // Case 6 [Passed]
        OptimizedDiskCache optimizedDiskCache = new OptimizedDiskCache();
        Cache cache = (Cache)optimizedDiskCache;
        DiskCache diskCache = (DiskCache)cache;
    }
}

