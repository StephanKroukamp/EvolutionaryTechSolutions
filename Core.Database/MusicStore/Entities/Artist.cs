using Google.Cloud.Firestore;

namespace Core.Database.MusicStore.Entities
{
    [FirestoreData]
    public class Artist
    {
        [FirestoreProperty]
        public string Title { get; set; }

        [FirestoreProperty]
        public string Description { get; set; }
    }
}