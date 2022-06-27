using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMiniProject.Interfaces;

public interface IReferenceManager <T, V>
{
    public void AddNewReference(T t, V v);
    public void DeleteCurrentReference(T t);
    public void DeleteCurrentReference(T t, V v);
    public void ReplaceCurrentReference(T t, V v);
}
