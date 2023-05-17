namespace Demo_Caisse.Services
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _env; 
        // service qui donne des informations sur l'environnement de l'application*
        // exemple : le chemin vers le dossier wwwroot sur le serveur

        public UploadService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string Upload(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }
            string guid = Guid.NewGuid().ToString(); // identifiant unique => c'est une chaine de caractères très longue composée de lettres, chiffres et -
            string nomFichier = guid + "-" + file.FileName; // ici il sera donc impossible d'avoir 2 fois le même nom de fichier => évite les conflits
            string pathServer = Path.Combine(_env.WebRootPath, "images", nomFichier); // chemin du dossier wwwroot sur le serveur
            FileStream stream = File.Create(pathServer); // on crée le fichier, il est vide
            file.CopyTo(stream); // on copie le contenu dans le nouveau fichier
            stream.Close(); // on ferme le fichier

            return "/images/" + nomFichier; // on retourne le chemin du fichier sur le navigateur (le dossier wwwroot correspond à la racine)
        }

        public void Remove(string filePath)
        {
            string pathServer = Path.Combine(_env.WebRootPath, filePath);
            File.Delete(pathServer);
        }
    }
}
