namespace DirFileLocation.XunitTest
{
    public class DirectoryListingTests
    {
        [Fact]

        public void GetDirectoryListing_ReturnsValidResult()
        {
            // Arrange
            string directoryPath = "C:\\Users\\Username\\Documents";
            var directoryInfo = new DirectoryInfo(directoryPath);

            // Act
            var result = GetDirectoryListing(directoryInfo);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        private string GetDirectoryListing(DirectoryInfo directoryInfo)
        {
            var result = string.Empty;

            try
            {
                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    result += $"{fileInfo.Directory} ({fileInfo.Length} bytes) {fileInfo.Attributes}\n";
                }

                foreach (var subdirectoryInfo in directoryInfo.GetDirectories())
                {
                    result += GetDirectoryListing(subdirectoryInfo);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                result = ex.Message;
            }

            return result;
        }
    }
}