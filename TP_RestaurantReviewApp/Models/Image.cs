using system;

public class image
{
    private string fileLocation;
    private string caption;
    private string storagesize;
    private int imageId;

    
    //default constructor
    public image()
    {
        fileLocation = string.Empty;
        caption = string.Empty;
        storagesize = string.Empty;
        imageId = -1;
        
    }

    //parameterized
    public image(string FileLocation, string Caption, string StorageSize, int ImageId)
    {
        this.fileLocation = FileLocation;
        this.caption = Caption;
        this.storagesize = StorageSize;
        this.imageId = ImageId;
    }

    //getters, setters
    public string FileLocation { get { return fileLocation; } set { this.fileLocation = value; } }
    public string Caption { get { return caption; } set { this.caption = value; } }
    public string StorageSize { get { return StorageSize; } set { this.StorageSize = value; } }
    public int ImageId { get { return imageId; } set { this.imageId = value; } }
}
