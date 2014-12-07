﻿using UnityEngine;

    /// <summary>
    /// The amount of gray scale color variance to apply
    /// </summary>
    public float ColorVariance = 0.0f;

    /// <summary>
    /// The initial color of the decal
    /// </summary>
    private Color m_initialColor = Color.white;

    /// <summary>
    /// The faded color of the decal
    /// </summary>
    private Color m_fadedColor = Color.white;

        var grayScale = (1.0f - this.ColorVariance) + Random.Range(0.0f, this.ColorVariance);
        m_initialColor = new Color(grayScale, grayScale, grayScale);
        m_fadedColor = new Color(grayScale, grayScale, grayScale, 0.0f);
        m_decal.color = m_initialColor;
                var fadeColor = Color.Lerp(m_initialColor, m_fadedColor, progress);