﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Castle.Sharp2Js.SampleData;
using Castle.Sharp2Js.Tests.DTOs;
using NUnit.Framework;

namespace Castle.Sharp2Js.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class JsGeneratorTests
    {
        [Test]
        public void BasicGenerationLegacy()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof (AddressInformation);

#pragma warning disable 618
            var outputJs = JsGenerator.GenerateJsModelFromTypeWithDescendants(modelType, true, "castle");
#pragma warning restore 618

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void RecursiveTypeGenerationLegacy()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof (RecursiveTest);

#pragma warning disable 618
            var outputJs = JsGenerator.GenerateJsModelFromTypeWithDescendants(modelType, true, "castle");
#pragma warning restore 618

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void BasicGeneration()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof (AddressInformation);

            var outputJs = JsGenerator.Generate(new[] {modelType});

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void BasicGenerationWithOptions()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof (AddressInformation);

            var outputJs = JsGenerator.Generate(new[] {modelType}, new JsGeneratorOptions()
            {
                ClassNameConstantsToRemove = new List<string>() {"Dto"},
                CamelCase = true,
                IncludeMergeFunction = false,
                OutputNamespace = "models"
            });

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void ArrayTypeHandling()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof (ArrayTypeTest);

            var outputJs = JsGenerator.Generate(new[] {modelType}, new JsGeneratorOptions()
            {
                ClassNameConstantsToRemove = new List<string>() {"Dto"},
                CamelCase = true,
                IncludeMergeFunction = false,
                OutputNamespace = "models"
            });

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void DataMemberAttributeHandling()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof(AttributeInformationTest);

            var outputJs = JsGenerator.Generate(new[] { modelType }, new JsGeneratorOptions()
            {
                ClassNameConstantsToRemove = new List<string>() { "Dto" },
                CamelCase = true,
                IncludeMergeFunction = false,
                OutputNamespace = "models",
                RespectDataMemberAttribute = true
            });

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void DefaultValueHandling()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof(AttributeInformationTest);

            var outputJs = JsGenerator.Generate(new[] { modelType }, new JsGeneratorOptions()
            {
                ClassNameConstantsToRemove = new List<string>() { "Dto" },
                CamelCase = true,
                IncludeMergeFunction = false,
                OutputNamespace = "models",
                RespectDataMemberAttribute = true,
                RespectDefaultValueAttribute = true
            });

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void UnexpectedStateHandling()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof(AttributeInformationTest);

            var outputJs = JsGenerator.Generate(new[] { modelType }, new JsGeneratorOptions()
            {
                ClassNameConstantsToRemove = null,
                CamelCase = true,
                IncludeMergeFunction = false,
                OutputNamespace = "models",
                RespectDataMemberAttribute = false,
                RespectDefaultValueAttribute = false
            });

            Assert.IsTrue(!string.IsNullOrEmpty(outputJs));

            var js = new Jint.Parser.JavaScriptParser();

            try
            {
                js.Parse(outputJs);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception parsing javascript, but got: " + ex.Message);
            }


        }

        [Test]
        public void FatalStateHandling()
        {
            //Generate a basic javascript model from a C# class

            var modelType = typeof(AttributeInformationTest);
            var tempOptions = JsGenerator.Options;
            JsGenerator.Options = null;

            Assert.Catch<ArgumentNullException>((() =>
            {
                var outputJs = JsGenerator.Generate(new[] { modelType });
            }), "Expected engine to throw ArguementNullException when Options are null");

            JsGenerator.Options = tempOptions;

        }

    }

    
}
