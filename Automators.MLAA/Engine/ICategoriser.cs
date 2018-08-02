using System.Collections.Generic;
using Entity;

namespace Engine
{
    public interface ICategoriser
    {
        List<TestDataResult> Categorise(List<string> testData);
    }
}