using EF.DAL.Entities;
using EF.DAL;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class StudentService
{
    private StudentRepository _StudentRepository;
    public StudentService()
    {
        _StudentRepository = new StudentRepository();
    }

    public List<Student> GetAll()
    {
        return _StudentRepository.GetAll().ToList();
    }

    public List<Student> GetAllById(int id)
    {


        return _StudentRepository.GetAll()
                                    .Where(s => s.Id == id)
                                    .ToList();
    }

    public List<Student> GetAllByName(string name)
    {
        return _StudentRepository.GetAll()
                                    .Where(s => s.Name == name)
                                    .ToList();
    }

    public Student? GetByName(string name)
    {
        return _StudentRepository.GetAll()
                                    .FirstOrDefault(s => s.Name == name);
    }

   
    public void DeleteByName(Student students, string name)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Name == name)
                                        .ToList();
        _StudentRepository.Delete(res);
    }

    public void DeleteByDesc(List<Student> students, string desc)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Description == desc)
                                        .ToList();
        _StudentRepository.Delete(res);
    }
    public void DeleteByDesc(Student students, string desc)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Description == desc)
                                        .ToList();
        _StudentRepository.Delete(res);
    }

    public void DeleteById(int id)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Id == id)
                                        .ToList();
        _StudentRepository.Delete(res);
    }


    public void UpdateByName(List<Student> students, string name)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Name == name)
                                        .ToList();
        _StudentRepository.Update(res);
    }

    public void UpdateByName(Student students, string name)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Name == name)
                                        .ToList();
        _StudentRepository.Update(res);
    }

    public void UpdateByDesc(List<Student> students, string Desc)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Description == Desc)
                                        .ToList();
        _StudentRepository.Update(res);
    }
    public void UpdateByDesc(Student students, string Desc)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Description == Desc)
                                        .ToList();
        _StudentRepository.Update(res);
    }
    public void UpdateById(int Id)
    {
        var res = _StudentRepository.GetAll()
                                         .Where(s => s.Id == Id)
                                        .ToList();
        _StudentRepository.Update(res);
    }
    public void Add(Student student)
    {
        _StudentRepository.Add(student);
    }   

}