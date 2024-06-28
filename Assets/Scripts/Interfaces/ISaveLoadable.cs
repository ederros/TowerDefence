using System;

public interface ISaveLoadable
{
    Type GetSavedDataType();
    void Save(out object data);
    void Load(object data);
}
