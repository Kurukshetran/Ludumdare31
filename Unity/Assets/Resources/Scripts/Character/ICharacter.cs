﻿using UnityEngine;
    protected ICharacterAnimationController m_animationController = null;

        m_animationController = this.GetComponent<ICharacterAnimationController>();
        if (m_animationController == null)
        {
            Debug.LogError(string.Format("The character {0} does not have an animation controller component.", this.name));
            this.gameObject.SetActive(false);
        }