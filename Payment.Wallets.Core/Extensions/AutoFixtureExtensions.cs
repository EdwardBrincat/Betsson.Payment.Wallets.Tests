// ReSharper disable once CheckNamespace

using AutoFixture.Dsl;

namespace AutoFixture;

public static class AutoFixtureExtensions
{
    public static IPostprocessComposer<T> BuildTyrData<T>(this Fixture fixture) => fixture.Build<T>().OmitAutoProperties();
}