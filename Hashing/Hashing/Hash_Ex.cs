﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    /// <summary>
    /// class-
    /// Keys--Holds the Keys,Keys is an array of HashMap Type
    /// tableSize-//define size of keys and calculate hash
    /// </summary>
    public class Hash_Ex<K, V>
    {
        private HashMap<K, V>[] Keys;
        private readonly int tableSize;

        public Hash_Ex(int maxTableSize)//Constructor
        {
            tableSize = maxTableSize;
            Keys = new HashMap<K, V>[tableSize];
        }
        /// <summary>
        /// Hash Function
        /// </summary>
        /// <param name="Key"></param>
        private int HashFuncation(K key)
        {
            int position = key.GetHashCode() % tableSize; //identifying hash code of key
            return Math.Abs(position);
        }
        /// <summary>
        /// Insert value with key to table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param> 
        public void Insert(K key, V value)
        {
            int genIndex = HashFuncation(key);//generates hash index
            HashMap<K, V> node = Keys[genIndex];

            if (node == null)
            {
                Keys[genIndex] = new HashMap<K, V>() { Key = key, Value = value };
                return;
            }
            HashMap<K, V> newNode = new HashMap<K, V>() { Key = key, Value = value, Previous = node, Next = null };
            node.Next = newNode;
        }
        /// <summary>
        /// get values by their key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>value</returns>
        /// <exception cref="Exception">Don't have the key in hash</exception>
        public V GetValue(K key)
        {
            int genIndex = HashFuncation(key);
            HashMap<K, V> node = Keys[genIndex];
            while (node != null)//search the linked list to match the key
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
                node = node.Next;
            }

            throw new Exception("Don't have the key in hash!");
        }
    }
}