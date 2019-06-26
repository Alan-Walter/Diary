namespace Diary
{
    /// <summary>
    /// Интерфейс пути до файла базы данных
    /// </summary>
    public interface IDatabasePath
    {
        /// <summary>
        /// Метод, возвращающий путь до файла бд
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Путь</returns>
        string GetDatabasePath(string filename);
    }
}
