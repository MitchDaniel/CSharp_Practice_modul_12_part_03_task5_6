namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoveDirectory(@"C:\Users\Brill\Desktop\Новая папка\oldPath", @"C:\Users\Brill\Desktop\Новая папка\newPath");
        }
        static void MoveDirectory(string oldPath, string newPath)
        {
            if (oldPath is null) throw new ArgumentNullException(nameof(oldPath));
            if (newPath is null) throw new ArgumentNullException(nameof(newPath));
            if (!Directory.Exists(oldPath)) throw new DirectoryNotFoundException(nameof(oldPath));
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            foreach (var file in Directory.GetFiles(oldPath))
            {
                var destFile = Path.Combine(newPath, Path.GetFileName(file));
                File.Move(file, destFile);
            }
            foreach (var dir in Directory.GetDirectories(oldPath))
            {
                var destDir = Path.Combine(newPath, Path.GetFileName(dir));
                MoveDirectory(dir, destDir);
            }
            Directory.Delete(oldPath, true);
        }
    }
}

//Задание 5:
//Создайте приложение для перемещения папок. 
//Пользователь вводит путь к оригинальной папке и путь к тому месту куда нужно переместить папку. 
//Приложение должно сообщить об успешности или неуспешности операции.
//Добавьте к приложению возможность перемещения папок с подпапками.