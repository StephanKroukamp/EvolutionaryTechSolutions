using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Database.MusicStore.Entities;
using Google.Cloud.Firestore;

namespace Core.Database.MusicStore
{
    public class ArtistRepository
    {
        private const string collectionName = "artists";

        private readonly FirestoreDb firestoreDb;

        public ArtistRepository(FirestoreDb firestoreDb)
        {
            this.firestoreDb = firestoreDb;
        }

        public async Task<WriteResult> AddAsync(Artist artist)
        {
            string documentId = artist.Title.Trim();
            
            documentId = documentId.Replace(" ", "");

            string firstLetterToLowerCase = documentId.Substring(0, 1).ToLower();

            documentId = firstLetterToLowerCase + documentId.Substring(1);

            DocumentReference docRef = firestoreDb.Collection(collectionName).Document(documentId);

            return await docRef.SetAsync(artist);
        }

        public async Task<List<Artist>> Get()
        {
            QuerySnapshot capitalQuerySnapshot = await firestoreDb.Collection(collectionName).GetSnapshotAsync();

            List<Artist> artists = new List<Artist>();

            foreach (DocumentSnapshot documentSnapshot in capitalQuerySnapshot.Documents)
            {
                Artist artist = documentSnapshot.ConvertTo<Artist>();

                artists.Add(artist);
            }

            return artists;
        }
    }
}