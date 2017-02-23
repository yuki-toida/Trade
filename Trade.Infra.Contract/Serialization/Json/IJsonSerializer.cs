using System;

namespace Trade.Infra.Contract.Serialization.Json
{
    /// <summary>
    /// JSON のシリアライザーを共通化するためのインターフェイスです。
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// パラメータで指定したインスタンスを文字列にJSON文字列にシリアライズします。
        /// </summary>
        /// <param name="obj">シリアライズ対象のインスタンス</param>
        /// <returns>シリアライズされたJSON文字列</returns>
        string Serialize(object obj);

        /// <summary>
        /// パラメータで指定したJSON文字列をデシリアライズします。
        /// </summary>
        /// <param name="json">デシリアライズ対象のJSON文字列</param>
        /// <returns>デシリアライズされたオブジェクトのインスタンス</returns>
        /// <remarks>実装ライブラリによっては独自のdynamic型を返すことに注意して下さい。</remarks>
        object Deserialize(string json);

        /// <summary>
        /// パラメータで指定したJSON文字列をジェネリックパラメータで指定した型にデシリアライズします。
        /// </summary>
        /// <typeparam name="T">どの型にデシリアライズされるかを指定します。object型を指定した場合、実装ライブラリによっては独自のdynamic型を返すことに注意して下さい。</typeparam>
        /// <param name="json">デシリアライズ対象のJSON文字列</param>
        /// <returns>デシリアライズされたオブジェクトのインスタンス</returns>
        T Deserialize<T>(string json);

        /// <summary>
        /// パラメータで指定したJSON文字列をパラメータで指定した型にデシリアライズします。
        /// </summary>
        /// <param name="json">デシリアライズ対象のJSON文字列</param>
        /// <param name="type">どの型にデシリアライズされるかを指定します。object型を指定した場合、実装ライブラリによっては独自のdynamic型を返すことに注意して下さい。</param>
        /// <returns>デシリアライズされたオブジェクトのインスタンス</returns>
        object Deserialize(string json, Type type);
    }
}
