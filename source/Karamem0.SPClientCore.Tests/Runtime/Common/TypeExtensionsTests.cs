//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common.Tests;

[Category("Karamem0.SharePoint.PowerShell.Runtime")]
public class TypeExtensionsTests
{

    [JsonObject()]
    public class TestClass<T>
    {
    }

    public class TestSubClass<T> : TestClass<T>
    {
    }

    [Test()]
    public void IsGenericSubclassOf_SameType_ReturnsTrue()
    {
        var args = new
        {
            TargetType = typeof(TestClass<int>),
            GenericType = typeof(TestClass<>)
        };
        var expected = true;
        var actual = TypeExtensions.IsGenericSubclassOf(args.TargetType, args.GenericType);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void IsGenericSubclassO_InheritedType_ReturnsTrue()
    {
        var args = new
        {
            TargetType = typeof(TestSubClass<int>),
            GenericType = typeof(TestClass<>)
        };
        var expected = true;
        var actual = TypeExtensions.IsGenericSubclassOf(args.TargetType, args.GenericType);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void IsGenericSubclassOf_DiffrentType_ReturnsFalse()
    {
        var args = new
        {
            TargetType = typeof(TestClass<int>),
            GenericType = typeof(List<>)
        };
        var expected = false;
        var actual = TypeExtensions.IsGenericSubclassOf(args.TargetType, args.GenericType);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void GetCustomAttribute_DeclaredAttribute_ReturnsAtttribute()
    {
        var args = new
        {
            Type = typeof(TestClass<>)
        };
        var expected = typeof(JsonObjectAttribute);
        var actual = TypeExtensions.GetCustomAttribute<JsonObjectAttribute>(args.Type);
        Assert.That(actual, Is.InstanceOf(expected));
    }

    [Test()]
    public void GetCustomAttribute_InheritedAttribute_ReturnsAtttribute()
    {
        var args = new
        {
            Type = typeof(TestSubClass<>)
        };
        var expected = typeof(JsonObjectAttribute);
        var actual = TypeExtensions.GetCustomAttribute<JsonObjectAttribute>(args.Type);
        Assert.That(actual, Is.InstanceOf(expected));
    }

    [Test()]
    public void GetCustomAttribute_InheritedAttribute_ReturnsNull()
    {
        var args = new
        {
            Type = typeof(TestSubClass<>),
            Inherited = false
        };
        var expected = (JsonObjectAttribute)null;
        var actual = TypeExtensions.GetCustomAttribute<JsonObjectAttribute>(args.Type, args.Inherited);
        Assert.That(actual, Is.EqualTo(expected));
    }

}
