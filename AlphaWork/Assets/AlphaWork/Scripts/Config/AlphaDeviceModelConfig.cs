using System.Collections.Generic;
using UnityEngine;

namespace AlphaWork
{
    public class AlphaDeviceModelConfig : ScriptableObject
    {
        [SerializeField]
        private List<AlphaDeviceModel> m_DeviceModels = null;

        public AlphaDeviceModel[] GetDeviceModels()
        {
            return m_DeviceModels.ToArray();
        }

        public void NewDeviceModel()
        {
            m_DeviceModels.Add(new AlphaDeviceModel());
        }

        public void RemoveDeviceModelAt(int index)
        {
            m_DeviceModels.RemoveAt(index);
        }

        public QualityLevelType GetDefaultQualityLevel()
        {
            string modelName = SystemInfo.deviceModel;
            for (int i = 0; i < m_DeviceModels.Count; i++)
            {
                if (m_DeviceModels[i].ModelName == modelName)
                {
                    return m_DeviceModels[i].QualityLevel;
                }
            }

            return QualityLevelType.Fastest;
        }
    }
}
